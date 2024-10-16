using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Models
{
    public class phantrang<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public phantrang(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static phantrang<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new phantrang<T>(items, count, pageIndex, pageSize);
        }
    }
}
