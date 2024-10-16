using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;

namespace Web_my_pham.Services.ClientServices.Irepository
{
   public interface IDanhMucRepositoryClient
    {
        List<DANH_MUC_SAN_PHAM> getall();
    }
}
