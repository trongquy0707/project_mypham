using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.ClientServices;
using Web_my_pham.Services.ClientServices.Irepository;

namespace Web_my_pham.Services.ClientServices.Repository
{
    public class DanhMucRepositoryClient : IDanhMucRepositoryClient
    {
        private readonly MyDbContext _myDbContext;
        public DanhMucRepositoryClient(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public List<DANH_MUC_SAN_PHAM> getall()
        {
            try
            {
                var listcategory = _myDbContext.DANH_MUC_SAN_PHAM.ToList();
                return listcategory;
            } catch
            {
                throw new KeyNotFoundException($"Không tìm thấy danh muc ");
            }
         
        }
    }
}
