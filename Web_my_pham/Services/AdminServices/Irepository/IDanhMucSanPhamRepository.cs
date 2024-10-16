using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Models;
using Web_my_pham.Data;
namespace Web_my_pham.Services.AdminServices.Irepository
{
   public interface IDanhMucSanPhamRepository
    {
        List<DANH_MUC_SAN_PHAM> Getall();
        Task<DANH_MUC_SAN_PHAM> ThemDanhMuc(DanhMucSanPhamModels obj);
        Task<DANH_MUC_SAN_PHAM> SuaDanhMuc(DanhMucSanPhamModels obj, int id);
        void XoaDanhMuc(int id);
        DANH_MUC_SAN_PHAM GetbyId(int id);

    }
}
