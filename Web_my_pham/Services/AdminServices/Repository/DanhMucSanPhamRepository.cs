
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Services.AdminServices.Repository
{
    public class DanhMucSanPhamRepository : IDanhMucSanPhamRepository
    {
        private readonly MyDbContext _myDbContext;
        private IWebHostEnvironment _environment;
        public DanhMucSanPhamRepository(MyDbContext myDbContext, IWebHostEnvironment environment)
        {
            _myDbContext = myDbContext;
            _environment = environment;
        }

        public List<DANH_MUC_SAN_PHAM> Getall()
        {
            var list = _myDbContext.DANH_MUC_SAN_PHAM.ToList(); ;
            return list;
        }

        public DANH_MUC_SAN_PHAM GetbyId(int id)
        {
            
            var danhmuc = _myDbContext.DANH_MUC_SAN_PHAM.FirstOrDefault(m => m.MaDanhMuc == id);
            if (danhmuc == null)
            {
                return null;
            }


            return new DANH_MUC_SAN_PHAM
            {
                MaDanhMuc = danhmuc.MaDanhMuc,
                TenDangMuc = danhmuc.TenDangMuc,
                AnhDanhMuc = danhmuc.AnhDanhMuc,
            };
        }

        public async Task<DANH_MUC_SAN_PHAM> SuaDanhMuc(DanhMucSanPhamModels obj, int id)
        {

            try
            {
                var crrObj = await _myDbContext.DANH_MUC_SAN_PHAM.FirstOrDefaultAsync(m => m.MaDanhMuc == id);

                if (crrObj == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy danh mục sản phẩm với ID = {id}");
                }

                crrObj.TenDangMuc = obj.TenDangMuc;

                if (obj.AnhDanhMuc != null)
                {
                    var path = Path.Combine(_environment.WebRootPath, "images/", obj.AnhDanhMuc.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await obj.AnhDanhMuc.CopyToAsync(stream);
                        stream.Close();
                    }
                    var luu = "/images/" + obj.AnhDanhMuc.FileName;
                    crrObj.AnhDanhMuc = luu;
                }

                await _myDbContext.SaveChangesAsync(); // Lưu các thay đổi bao gồm cả ảnh (nếu có)
                return crrObj;
                   
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tùy thuộc vào yêu cầu của bạn
                throw new Exception("Có lỗi xảy ra khi cập nhật danh mục sản phẩm.", ex);
            }

        }



        public async Task<DANH_MUC_SAN_PHAM> ThemDanhMuc(DanhMucSanPhamModels obj)
        {
            try
            {
                var danhmuc = new DANH_MUC_SAN_PHAM
                {
                    TenDangMuc = obj.TenDangMuc,
                };

                _myDbContext.DANH_MUC_SAN_PHAM.Add(danhmuc);

                if (obj.AnhDanhMuc != null && obj.AnhDanhMuc.Length > 0)
                {
                    var path = Path.Combine(_environment.WebRootPath, "images/", obj.AnhDanhMuc.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await obj.AnhDanhMuc.CopyToAsync(stream);
                    }

                    var luu = "/images/" + obj.AnhDanhMuc.FileName;
                    danhmuc.AnhDanhMuc = luu;
                }

                await _myDbContext.SaveChangesAsync();
                return danhmuc;

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while updating the entries. Inner exception: {innerException}");
            }
        }

        public void XoaDanhMuc(int id)
        {
            var timdanhmuc = _myDbContext.DANH_MUC_SAN_PHAM.Find(id);
            if (timdanhmuc != null)
            {
                _myDbContext.DANH_MUC_SAN_PHAM.Remove(timdanhmuc);
                _myDbContext.SaveChanges();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy danh mục sản phẩm với ID = {id}");
            }
        }
    }
}
