using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
namespace Web_my_pham.Services.ClientServices.Irepository
{
   public interface ISanPhamRepositorty
    {
        List<SAN_PHAM_CHI_TIET> getsanphamsale();
        List<SAN_PHAM_CHI_TIET> getsanphamishome();
        SAN_PHAM_CHI_TIET chitietsanpham(int id); 
        List<SAN_PHAM_CHI_TIET> sanphamtheodanhmuc(int id);
        List<SAN_PHAM_CHI_TIET> sanphamchung(string search);
    }
}
