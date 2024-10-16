using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Services.AdminServices.Repository
{
    public class SanPhamChiTietRepository : ISanPhamChiTietRepository
    {
        private readonly MyDbContext _myDbContext;
        private IWebHostEnvironment _environment;
        public static int PAGE_SIZE { get; set; } = 5;
        public SanPhamChiTietRepository(MyDbContext myDbContext, IWebHostEnvironment environment)
        {
            _myDbContext = myDbContext;
            _environment = environment;
        }
        public List<SAN_PHAM_CHI_TIET> getall()
        {
            var sanpham = _myDbContext.SAN_PHAM_CHI_TIET.ToList();

            return sanpham;
        }
        public SAN_PHAM_CHI_TIET themmoi(SAN_PHAM_CHI_TIET obj, List<string> Images, List<int> rDefault)
        {
            try
            {
                if (obj != null)
                {
                    if (Images != null && Images.Count > 0)
                    {
                        for (int i = 0; i < Images.Count; i++)
                        {
                            if (i + 1 == rDefault[0])
                            {
                                obj.HinhAnhChinh = Images[i];
                                obj.HINH_ANH.Add(new HINH_ANH
                                {
                                    MaSanPham = obj.MaSP,
                                    HinhAnh = Images[i],
                                    AnhChinh = true
                                });
                            }
                            else
                            {
                                obj.HINH_ANH.Add(new HINH_ANH
                                {
                                    MaSanPham = obj.MaSP,
                                    HinhAnh = Images[i],
                                    AnhChinh = false
                                });
                            }
                        }
                    }
                    var sale = obj.GiaSale;
                    sale = (obj.GiaGoc / 100) * obj.PhanTramSale;
                    obj.GiaSale = (obj.GiaGoc - sale);
                    obj.TrangThai = 1;

                    _myDbContext.SAN_PHAM_CHI_TIET.Add(obj);
                    _myDbContext.SaveChanges();
                    return obj;
                }
                return obj;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu đối tượng: {ex.Message}");
                Console.WriteLine($"Chi tiết: {ex.StackTrace}");
                Console.WriteLine($"MaSP: {obj.MaSP}, MaSanPham: {obj.HINH_ANH.FirstOrDefault()?.MaSanPham}");

                throw;
            }
        }



        public SAN_PHAM_CHI_TIET getbyId(int id)
        {
            var sanpham = _myDbContext.SAN_PHAM_CHI_TIET.FirstOrDefault(m => m.MaSP == id);
            return new SAN_PHAM_CHI_TIET
            {
                MaSP = sanpham.MaSP,
                MaDanhMuc = sanpham.MaDanhMuc,
                TenSanPham = sanpham.TenSanPham,
                HinhAnhChinh = sanpham.HinhAnhChinh,
                GiaGoc = sanpham.GiaGoc,
                GiaSale = sanpham.GiaSale,
                MoTaChiTiet = sanpham.MoTaChiTiet,
                PhanTramSale = sanpham.PhanTramSale,
                isHome = sanpham.isHome,
                isSale = sanpham.isSale,
                TrangThai = sanpham.TrangThai,
            };
        }

        public void ishome(int id)
        {
            var item = _myDbContext.SAN_PHAM_CHI_TIET.Find(id);
            if (item != null)
            {
                item.isHome = !item.isHome;
                _myDbContext.SaveChanges();
            }

        }

        public void isSale(int id)
        {
            var item = _myDbContext.SAN_PHAM_CHI_TIET.Find(id);
            if (item != null)
            {
                item.isSale = !item.isSale;
                _myDbContext.SaveChanges();
            }
        }

        public async Task<SAN_PHAM_CHI_TIET> suasanpham(int id, SAN_PHAM_CHI_TIET_REQUEST model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            var sanpham = await _myDbContext.SAN_PHAM_CHI_TIET.FindAsync(id);
            if (sanpham == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            // Cập nhật thông tin sản phẩm
            sanpham.TenSanPham = model.TenSanPham;
            sanpham.MaDanhMuc = model.MaDanhMuc;
            sanpham.GiaGoc = model.GiaGoc;
            sanpham.GiaSale = model.GiaSale;
            sanpham.isHome = model.isHome;
            sanpham.isSale = model.isSale;
            sanpham.PhanTramSale = model.PhanTramSale;
            sanpham.MoTaChiTiet = model.MoTaChiTiet;
            sanpham.TrangThai = model.TrangThai;

            // Tính toán giá sale
            if (sanpham.GiaGoc > 0 && sanpham.PhanTramSale >= 0)
            {
                var sale = (sanpham.GiaGoc / 100) * sanpham.PhanTramSale;
                sanpham.GiaSale = sanpham.GiaGoc - sale;
            }

            // Lưu các thay đổi sản phẩm
            await _myDbContext.SaveChangesAsync();

            // Xử lý hình ảnh
            if (model.HinhAnhChinh != null)
            {
                var path = Path.Combine(_environment.WebRootPath, "images/", model.HinhAnhChinh.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await model.HinhAnhChinh.CopyToAsync(stream);
                }
                var luu = "/images/" + model.HinhAnhChinh.FileName;
                sanpham.HinhAnhChinh = luu;
                await _myDbContext.SaveChangesAsync(); // Lưu hình ảnh
            }

            return sanpham;
        
    

    }


        public void xoasanpham(int id)
        {
            var sanpham = _myDbContext.SAN_PHAM_CHI_TIET.FirstOrDefault(m => m.MaSP == id);
            if (sanpham != null)
            {
                _myDbContext.SAN_PHAM_CHI_TIET.Remove(sanpham);
                _myDbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy sản phẩm cần xóa");
            }

        }

        public async Task<SAN_PHAM_CHI_TIET> themmoitesst(SAN_PHAM_CHI_TIET_REQUEST model)
        {
            try
            {
                
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model), "Model cannot be null.");
                }

                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model), "Obj in model cannot be null.");
                }

                var userModel = new SAN_PHAM_CHI_TIET
                {

                    TenSanPham = model.TenSanPham,
                    MaDanhMuc = model.MaDanhMuc,
                    GiaGoc = model.GiaGoc,
                    GiaSale = model.GiaSale,
                    isHome = model.isHome,
                    isSale = model.isSale,
                    PhanTramSale = model.PhanTramSale,
                    MoTaChiTiet = model.MoTaChiTiet,
                    TrangThai = model.TrangThai,
                };

                // Thêm sản phẩm vào cơ sở dữ liệu trước khi thêm hình ảnh
                _myDbContext.SAN_PHAM_CHI_TIET.Add(userModel);
                await _myDbContext.SaveChangesAsync(); // Lưu sản phẩm để có MaSP

                if (model.Images != null && model.Images.Count > 0)
                {
                    var rDefaultList = model.RDefault ?? new List<int>();
                    foreach (var item in model.Images)
                    {
                        if (item == null || item.FileName.Length == 0)
                        {
                            throw new ArgumentException("Image file cannot be null or empty.", nameof(item));
                        }

                        var path = Path.Combine(_environment.WebRootPath, "images/", item.FileName);
                        using (FileStream stream = new FileStream(path, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }

                        //bool isMainImage = rDefaultList.Contains(model.Images.IndexOf(item) + 1) || rDefaultList.Count == 0 && model.Images.IndexOf(item) == 0;
                        bool isMainImage = rDefaultList.Contains(model.Images.IndexOf(item) + 1);
                        var luu = ("/images/" + item.FileName);
                        _myDbContext.HINH_ANH.Add(new HINH_ANH
                        {
                            MaSanPham = userModel.MaSP, // Sử dụng MaSP từ sản phẩm đã được lưu
                            HinhAnh = luu,
                            AnhChinh = isMainImage,
                        });
                        if (isMainImage == true)
                        {
                            userModel.HinhAnhChinh = luu;   
                        }


                    }

                    await _myDbContext.SaveChangesAsync(); // Lưu các hình ảnh
                }
                return userModel;
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while updating the entries. Inner exception: {innerException}");
            }
        }
    }
}
