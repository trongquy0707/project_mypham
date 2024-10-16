using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Services.AdminServices.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly MyDbContext _myDbContext;
        public TaiKhoanRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public List<TAI_KHOAN> Getall()
        {
            var taikhoan = _myDbContext.TAI_KHOAN.ToList();
            return taikhoan;
        }

        public TAI_KHOAN getbyid(int id)
        {
            var timkiem = _myDbContext.TAI_KHOAN.FirstOrDefault(m => m.MaUser == id);
            return timkiem;
        }

   
        public void suataikhoan(TAI_KHOAN obj, int id)
        {
            throw new NotImplementedException();
        }

        public TAI_KHOAN themmoi(TAI_KHOAN obj)
        {
            throw new NotImplementedException();
        }

       

        public void xoataikhoan(int id)
        {
            throw new NotImplementedException();
        }
    }
}
