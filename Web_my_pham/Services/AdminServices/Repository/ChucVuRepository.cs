using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Services.AdminServices
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly MyDbContext _myDbContext;
        public ChucVuRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<object> capquyen(int id,int machucvu)
        {
            try
            {
                var timkiem = _myDbContext.TAI_KHOAN.FirstOrDefault(x => x.MaUser == id);
                if (timkiem != null)
                {
                    timkiem.MaChucVu = machucvu;
                    _myDbContext.SaveChanges();
                    return new
                    {
                        Success = true,
                    };
                }
                return new
                {
                    Success = false,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CHUC_VU> getall()
        {
            var chucvu = _myDbContext.CHUC_VU.ToList();
            return chucvu;
        }

        public List<TAI_KHOAN> getalltaikhoan()
        {
            var getlltaikhoan = _myDbContext.TAI_KHOAN.ToList();
            return getlltaikhoan;
        }

        public CHUC_VU getbyid(int id)
        {
            var chucvu = _myDbContext.CHUC_VU.FirstOrDefault(m => m.MaChucVu == id);
            return chucvu;
        }

        public void suachucvu(CHUC_VU obj, int id)
        {
            var chucvu = _myDbContext.CHUC_VU.FirstOrDefault(m => m.MaChucVu == id);
            if (chucvu != null)
            {
                chucvu.TenChucVu = obj.TenChucVu;
                _myDbContext.SaveChanges();
            }
            else
            {

                throw new KeyNotFoundException($"Không tìm thấy chức vụ với ID = {id}");
            }
        }

        public CHUC_VU themmoi(CHUC_VU obj)
        {

            _myDbContext.CHUC_VU.Add(obj);
            _myDbContext.SaveChanges();
            return obj;

        }

        public void xoachucvu(int id)
        {
            var chucvu = _myDbContext.CHUC_VU.FirstOrDefault(m => m.MaChucVu == id);
            if (chucvu != null)
            {
                _myDbContext.CHUC_VU.Remove(chucvu);
                _myDbContext.SaveChanges();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy danh mục với id là {id}");
            }
        }
    }
}
