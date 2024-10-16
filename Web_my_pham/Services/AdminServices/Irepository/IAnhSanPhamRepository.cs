using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
namespace Web_my_pham.Services.AdminServices.Irepository
{
    public interface IAnhSanPhamRepository
    {
        List<HINH_ANH> getall(int id);
        Task <HINH_ANH> themanh(int idsanpham, HinhAnhModels models);
        void xoaanh(int idAnh);
        void xoaall(int idSanPham);
    }
}
