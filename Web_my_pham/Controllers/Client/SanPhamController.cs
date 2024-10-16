using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Services.ClientServices.Irepository;

namespace Web_my_pham.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepositorty _sanPhamRepositorty;
        public SanPhamController(ISanPhamRepositorty sanPhamRepositorty)
        {
            _sanPhamRepositorty = sanPhamRepositorty;
        }

        [HttpGet("chitietsanpham/{id}")]
        public IActionResult chitietsanpham(int id)
        {
            try
            {
                return Ok(_sanPhamRepositorty.chitietsanpham(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("sanphamtheodanhmuc/{id}")]
        public IActionResult sanphamtheodanhmuc( int id)
        {
            try
            {
                return Ok(_sanPhamRepositorty.sanphamtheodanhmuc(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("sanphamchung")]
        public IActionResult sanphamchung(string search )
        {
            try
            {
                return Ok(_sanPhamRepositorty.sanphamchung(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("sanphamishome")]
        public IActionResult sanphamishome()
        {
            try
            {
                return Ok(_sanPhamRepositorty.getsanphamishome());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("sanphamissale")]
        public IActionResult sanphamissale()
        {
            try
            {
                return Ok(_sanPhamRepositorty.getsanphamsale());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
