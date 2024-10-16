using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Microsoft.AspNetCore.Hosting;
using Web_my_pham.Services.AdminServices.Irepository;
namespace Web_my_pham.Services.AdminServices.Repository
{
    public class AnhSanPhamRepository : IAnhSanPhamRepository
    {
        private readonly MyDbContext _myDbContext;
        private IWebHostEnvironment _environment;
        public AnhSanPhamRepository(MyDbContext myDbContext, IWebHostEnvironment environment)
        {
            _myDbContext = myDbContext;
            _environment = environment;
        }
        public List<HINH_ANH> getall(int id)
        {
            var hinhanh = _myDbContext.HINH_ANH.Where(m => m.MaSanPham == id).ToList();
            if (hinhanh == null || !hinhanh.Any())
            {
                return new List<HINH_ANH>(); 
            }
            return hinhanh;


        }

        public async Task<HINH_ANH> themanh(int idsanpham, HinhAnhModels models)
        {

            HINH_ANH hinhAnhs = null;
            if (models.HinhAnh != null)
            {
               foreach(var item in models.HinhAnh)
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
                    var luu = ("/images/" + item.FileName);

                    var hinhAnh = new HINH_ANH
                    {
                        MaSanPham = idsanpham ,// Sử dụng MaSP từ sản phẩm đã được lưu
                        HinhAnh = luu,
                       
                    };
                    _myDbContext.HINH_ANH.Add(hinhAnh);
                    
                }
                await _myDbContext.SaveChangesAsync();
            }
            return hinhAnhs;
        }

        public void xoaall(int idSanPham)
        {
            var timanhsp = _myDbContext.HINH_ANH.FirstOrDefault(m => m.MaSanPham == idSanPham);
            if(timanhsp != null)
            {
                _myDbContext.HINH_ANH.Remove(timanhsp);
                _myDbContext.SaveChanges();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy ảnh sản phẩm với ID = {idSanPham}");
            }
        }

        public void xoaanh(int idAnh)
        {
            var timanh = _myDbContext.HINH_ANH.FirstOrDefault(m => m.MaHinhAnh == idAnh);
            if(timanh != null)
            {
                _myDbContext.HINH_ANH.Remove(timanh);
                _myDbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy ảnh sản phẩm với ID = {idAnh}");
            }
        }
    }
}
