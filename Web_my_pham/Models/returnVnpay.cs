using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class returnVnpay
    {
        public string Message { get; set; }
        public string TenKhachHang { get; set; }
        public bool IsSuccess { get; set; }
        public long Amount { get; set; }
    }
}
