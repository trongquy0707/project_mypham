using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Web_my_pham.Services.ClientServices.Irepository;

namespace Web_my_pham.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository _accountRepository;
        private readonly Appsetting _appsettings;
        public AccountController(IAccountRepository accountRepository, IOptionsMonitor<Appsetting> optionsMonitor)
        {
            _accountRepository = accountRepository;
            _appsettings = optionsMonitor.CurrentValue;

        }
        [HttpPost("loggin")]
        public async Task<IActionResult> loggin([FromForm] LogginModels logginModels)
        {
            var result = await _accountRepository.loggin(logginModels);
            if (!result.Success)
            {
                return Ok(new
                {
                    Success = false,
                    Message = result.Message
                });

            }
            var token = GenerateJwtToken(result.tai_khoan);

            return Ok(new
            {
                Success = true,
                Message = result.Message,
                taikhoan = result.tai_khoan,
                Token = token
            });
        }

        private string GenerateJwtToken(TAI_KHOAN user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secretkey);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.TenDangNhap),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("MaChucVu", user.MaChucVu.ToString()),
                new Claim("Id", user.MaUser.ToString()),
                new Claim("TokenId", Guid.NewGuid().ToString())
             };
            if (user.MaChucVu == 1)
            {

                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        [HttpPost("dangky")]
        public async Task<IActionResult> dangky([FromForm] RegisterModel registerModel)
        {
            
            if(registerModel.MatKhau == registerModel.ReurnMatKhau)
            {
                var reult = await  _accountRepository.register(registerModel);
                if (reult!= null)
                {
                    return Ok("đăng ký thành công");
                }
            }
            return Ok("xem lại thông tin");
        }
    }
}
