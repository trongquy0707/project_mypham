using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.ClientServices;
using Web_my_pham.Services.ClientServices.Irepository;

namespace Web_my_pham.Services.ClientServices.Repository
{
    public class SanPhamRepository : ISanPhamRepositorty
    {
        private readonly MyDbContext _myDbContext;
        public SanPhamRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public SAN_PHAM_CHI_TIET chitietsanpham(int id)
        {
            var sanphamchitiet = _myDbContext.SAN_PHAM_CHI_TIET.FirstOrDefault(m=>m.MaSP == id);
            return sanphamchitiet;
        }

        public List<SAN_PHAM_CHI_TIET> getsanphamishome()
        {
            var items = _myDbContext.SAN_PHAM_CHI_TIET.Where(x => x.isHome).ToList();
            return items;
        }

        public List<SAN_PHAM_CHI_TIET> getsanphamsale()
        {
            var items = _myDbContext.SAN_PHAM_CHI_TIET.Where(x => x.isSale).ToList();
            return items;
        }

        public List<SAN_PHAM_CHI_TIET> sanphamchung(string search)
        {
            var items = _myDbContext.SAN_PHAM_CHI_TIET.ToList();
            // Nếu có chuỗi tìm kiếm, thêm điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                items = items.Where(x => x.TenSanPham.Contains(search)).ToList();
            }

            return items;
        }

        public List<SAN_PHAM_CHI_TIET> sanphamtheodanhmuc(int id)
        {
            var sanphamdanhmuc = _myDbContext.SAN_PHAM_CHI_TIET.Where(m => m.MaDanhMuc == id).ToList();
            return sanphamdanhmuc;
        }
    }
}
