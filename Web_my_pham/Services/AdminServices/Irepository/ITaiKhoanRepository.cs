using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
namespace Web_my_pham.Services.AdminServices.Irepository
{
    public interface ITaiKhoanRepository
    {
        List<TAI_KHOAN> Getall();
        TAI_KHOAN themmoi(TAI_KHOAN obj);
        void suataikhoan(TAI_KHOAN obj, int id);
        void xoataikhoan(int id);
        TAI_KHOAN getbyid(int id);
    }
}
