using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class HinhAnhModels
    {
        public List<IFormFile> HinhAnh { get; set; }
        public int MaSanPham { get; set; }
    }
}
