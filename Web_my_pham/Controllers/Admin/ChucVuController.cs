using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Services.AdminServices;
using Web_my_pham.Data;
using Microsoft.AspNetCore.Authorization;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private IChucVuRepository _chucVuRepository;
        public ChucVuController(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }

        [HttpGet("Getall")]
        public IActionResult getall()
        {
            try
            {
                return Ok(_chucVuRepository.getall());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("themoi")]
        public IActionResult themmoi(CHUC_VU obj)
        {
            try
            {
                return Ok(_chucVuRepository.themmoi(obj));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("suachucvu/{id}")]
        public IActionResult suachucvu(CHUC_VU obj, int id)
        {
            try
            {
                _chucVuRepository.suachucvu(obj, id);
                return Ok("Cập nhâtj thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("xoachucvu/{id}")]
        public IActionResult Xoachucvu(int id)
        {
            try
            {
                _chucVuRepository.xoachucvu(id);
                return Ok("Cập nhật thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("getbyidchucvu/{id}")]
        public IActionResult getbyid(int id)
        {
            try
            {
                return Ok(_chucVuRepository.getbyid(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("getalltaikhoan")]
        public IActionResult getalltaikhoan()
        {
            var result = _chucVuRepository.getalltaikhoan();
            return Ok(result);
        }
        [HttpPost("capquyen")]
        public async Task<IActionResult> capquyentaikhoan( [FromForm] int id,[FromForm] int machucvu)
        {
            try
            {
                var resutl = await _chucVuRepository.capquyen(id,machucvu);
                return Ok(resutl);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
