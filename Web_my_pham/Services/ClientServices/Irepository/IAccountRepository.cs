using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;

namespace Web_my_pham.Services.ClientServices.Irepository
{
     public interface IAccountRepository
    {
       Task<(bool Success, string Message, TAI_KHOAN tai_khoan)> loggin(LogginModels logginModels);
        Task<IActionResult> register(RegisterModel registerModel);

    }
}
