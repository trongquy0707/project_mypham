using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class BaoCaoModels
    {
        public List<decimal> MonthlyRevenues {get ; set;}
        public decimal TotalRevenueFromBeginning { get; set; }
        public int TotalOrdersFromBeginning { get; set; }
        public int PendingOrdersCount { get; set; }
        public int CompletedOrdersCount { get; set; }
}
}
