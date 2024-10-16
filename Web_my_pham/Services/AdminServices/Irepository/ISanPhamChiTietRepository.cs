using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;

namespace Web_my_pham.Services.AdminServices.Irepository
{
   public interface ISanPhamChiTietRepository
    {
        List<SAN_PHAM_CHI_TIET> getall();
        SAN_PHAM_CHI_TIET getbyId(int id);
       
        SAN_PHAM_CHI_TIET themmoi(SAN_PHAM_CHI_TIET obj, List<string> Images, List<int> rDefault);
        Task<SAN_PHAM_CHI_TIET> suasanpham(int id, SAN_PHAM_CHI_TIET_REQUEST obj);
        void xoasanpham(int id);
        void ishome(int id);
        void isSale(int id);

        Task<SAN_PHAM_CHI_TIET> themmoitesst(SAN_PHAM_CHI_TIET_REQUEST obj);

    }
}
