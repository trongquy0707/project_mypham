using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Web_my_pham.Services.ClientServices.Irepository;

namespace Web_my_pham.Services.ClientServices.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _myDbContext;
        public AccountRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public Task<(bool Success, string Message, TAI_KHOAN tai_khoan)> loggin(LogginModels logginModels)
        {
            var matkhau = Crypto.Hash(logginModels.MatKhau);
            var tai_khoan = _myDbContext.TAI_KHOAN.FirstOrDefault(m => m.Email == logginModels.Email && matkhau == m.MatKhau);
            if (tai_khoan == null)
            {
                return Task.FromResult((false, "Đăng nhập thất bại", (TAI_KHOAN)null));
            }

            return Task.FromResult((true, "Đăng nhập thành công", tai_khoan));
        }

        public async Task<IActionResult> register(RegisterModel registerModel)
        {
            var checkEmail = _myDbContext.TAI_KHOAN.FirstOrDefault(m => m.Email == registerModel.Email);
            if (checkEmail != null)
            {
                return await Task.FromResult(new OkObjectResult("Email đã được sử dụng"));
            }
            else
            {
                string mahoa = Crypto.Hash(registerModel.MatKhau);
                TAI_KHOAN Tk = new TAI_KHOAN();
                Tk.Email = registerModel.Email;
                Tk.TenDangNhap = registerModel.HoTen;
                Tk.SDT = registerModel.SDT;
                Tk.MatKhau = mahoa;
                Tk.MaChucVu = 2;
                await _myDbContext.TAI_KHOAN.AddAsync(Tk);
                await _myDbContext.SaveChangesAsync();
                return new OkObjectResult("Đăng ký thành công");
            }
        }
    }
}
