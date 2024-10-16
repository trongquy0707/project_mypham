using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;

namespace Web_my_pham.Services.AdminServices.Irepository
{
    public  interface IChucVuRepository
    {
        List<CHUC_VU> getall();
        CHUC_VU themmoi(CHUC_VU obj);
        void suachucvu(CHUC_VU obj, int id);
        void xoachucvu(int id);
        CHUC_VU getbyid(int id);

        List<TAI_KHOAN> getalltaikhoan();
        Task<object> capquyen(int id,int machucvu);
        
    }
}
