using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class OrderViewModel
    {
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ThanhPho { get; set; }
        public string Quan_Huyen { get; set; }
        public string Xa_Phuong { get; set; }
        public string Ghi_Chu { get; set; }
        public int Thanh_Toan { get; set; }
        public int Thanh_Toan_VnPay { get; set; }
    }
}
