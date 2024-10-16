using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;

namespace Web_my_pham.Services.AdminServices.Irepository
{
    public interface IHoaDonRepository
    {
        List<HOA_DON> gethoadon();
        HOA_DON detailOrder(int id);
        List<object> ListOrder(int id);
       Task<object> CapNhatTT(int id, int trangthai);
        BaoCaoModels baocaodoanhthu();
        List<HOA_DON> getchoxacnhan();
        object xacnhandonhang();
    }
}
