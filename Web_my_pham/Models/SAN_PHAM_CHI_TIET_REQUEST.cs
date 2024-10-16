using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;

namespace Web_my_pham.Models
{
    public class SAN_PHAM_CHI_TIET_REQUEST
    {
      
        public string TenSanPham { get; set; }
        public IFormFile HinhAnhChinh { get; set; }
        public float GiaGoc { get; set; }
        public float GiaSale { get; set; }
        public string MoTaChiTiet { get; set; }
        public float PhanTramSale { get; set; }
        public bool isSale { get; set; }
        public bool isHome { get; set; }
        public int TrangThai { get; set; }
        public int MaDanhMuc { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<int> RDefault { get; set; }
    }
}
