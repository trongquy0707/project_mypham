using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Services.AdminServices.Repository
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly MyDbContext _myDbContext;
        public HoaDonRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public List<HOA_DON> gethoadon()
        {
            try
            {
                var getall = _myDbContext.HOA_DON.OrderByDescending(x => x.NgayMua).ToList();
                return getall;
            }
            catch
            {
                throw;
            }

        }
        public async Task<object> CapNhatTT(int id, int trangthai)
        {
            var item = _myDbContext.HOA_DON.Find(id);
            if (item != null)
            {
                _myDbContext.HOA_DON.Attach(item);
                item.Status = trangthai;
                _myDbContext.Entry(item).Property(x => x.Thanh_Toan).IsModified = true;
                _myDbContext.SaveChanges();
                return new
                {
                    Success = true,
                };
            }
            return new
            {
                Success = true,
            };
        }

        public HOA_DON detailOrder(int id)
        {
            var item = _myDbContext.HOA_DON.Find(id);
            return item;
        }

        public List<object> ListOrder(int id)
        {
            var item = _myDbContext.HOA_DON_CHI_TIET
         .Where(x => x.HOA_DON.MaHD == id)
         .Select(x => new
         {
             x.MaSP,
             x.SoLuongMua,
             x.GiaBan,
             TenSanPham = x.SAN_PHAM_CHI_TIET.TenSanPham,
             Thanhtien = x.SoLuongMua * x.GiaBan
         })
         .ToList();

            return item.Cast<object>().ToList();
        }

        public BaoCaoModels baocaodoanhthu()
        {
            // Khởi tạo danh sách để lưu tổng doanh thu của từng tháng
            List<decimal> monthlyRevenues = new List<decimal>();

            // Khởi tạo biến để tính tổng doanh thu từ trước đến nay
            decimal totalRevenueFromBeginning = 0;

            // Lặp qua từng tháng trong năm
            for (int month = 1; month <= DateTime.Now.Month; month++)
            {
                // Tính ngày đầu tiên và cuối cùng của tháng
                DateTime startDateOfMonth = new DateTime(DateTime.Now.Year, month, 1);
                DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

                // Tính tổng doanh thu của tháng hiện tại
                decimal totalRevenueInMonth = CalculateTotalRevenue(startDateOfMonth, endDateOfMonth);

                // Thêm tổng doanh thu của tháng vào danh sách
                monthlyRevenues.Add(totalRevenueInMonth);

                // Cập nhật tổng doanh thu từ trước đến nay
                totalRevenueFromBeginning += totalRevenueInMonth;
            }
            var totalOrdersFromBeginning = CalculateTotalOrdersFromBeginning();


            var pendingOrdersCount = CountPendingOrders();


            var completedOrdersCount = CountCompletedOrders();

            return new BaoCaoModels
            {
                MonthlyRevenues = monthlyRevenues,
                TotalRevenueFromBeginning = totalRevenueFromBeginning,
                TotalOrdersFromBeginning = totalOrdersFromBeginning,
                PendingOrdersCount = pendingOrdersCount,
                CompletedOrdersCount = completedOrdersCount,
            };
        }

        public decimal CalculateTotalRevenue(DateTime startDate, DateTime endDate)
        {

            var orders = _myDbContext.HOA_DON.Where(o => o.NgayMua >= startDate && o.NgayMua <= endDate).ToList();


            decimal totalRevenue = orders.Sum(o => (decimal)(o.TongTien ?? 0));

            return totalRevenue;
        }


        public string CalculateMostBoughtProduct(DateTime startDate, DateTime endDate)
        {
            var orderDetails = _myDbContext.HOA_DON_CHI_TIET
                                .Where(od => od.HOA_DON.NgayMua >= startDate && od.HOA_DON.NgayMua <= endDate)
                                .ToList();
            Dictionary<int, int> productQuantityMap = new Dictionary<int, int>();
            foreach (var orderDetail in orderDetails)
            {
                int productId = orderDetail.MaSP ?? 0;
                int quantity = orderDetail.SoLuongMua ?? 0;

                if (productQuantityMap.ContainsKey(productId))
                {
                    productQuantityMap[productId] += quantity;
                }
                else
                {
                    productQuantityMap.Add(productId, quantity);
                }
            }
            int maxQuantity = productQuantityMap.Values.Max();
            int mostBoughtProductId = productQuantityMap.FirstOrDefault(x => x.Value == maxQuantity).Key;
            var mostBoughtProduct = _myDbContext.SAN_PHAM_CHI_TIET.FirstOrDefault(p => p.MaSP == mostBoughtProductId);
            return mostBoughtProduct != null ? mostBoughtProduct.TenSanPham : "Không có sản phẩm được mua";
        }
        public int CalculateTotalOrdersFromBeginning()
        {
            var totalOrders = _myDbContext.HOA_DON.Count();

            return totalOrders;
        }
        public int CountPendingOrders()
        {
            var pendingOrders = _myDbContext.HOA_DON.Where(dh => dh.Status == 0).ToList();
            int pendingOrdersCount = pendingOrders.Count;

            return pendingOrdersCount;
        }


        public int CountCompletedOrders()
        {
            var completedOrders = _myDbContext.HOA_DON.Where(dh => dh.Status == 2).ToList();
            int completedOrdersCount = completedOrders.Count;
            return completedOrdersCount;
        }

        public List<HOA_DON> getchoxacnhan()
        {
            try
            {
                var timkiem = _myDbContext.HOA_DON.Where(x => x.Status == 1).ToList();
                return timkiem;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public object xacnhandonhang()
        {
            var timkiem = _myDbContext.HOA_DON.Where(x => x.Status == 1).ToList();
            if (timkiem != null)
            {
               foreach(var items in timkiem)
                {
                    items.Status = 2;
                }
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
           
    }
}
