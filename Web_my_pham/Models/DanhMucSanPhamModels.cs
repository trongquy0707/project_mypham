using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class DanhMucSanPhamModels
    {
      
        public IFormFile AnhDanhMuc { get; set; }
        public string TenDangMuc { get; set; }
    }
}
