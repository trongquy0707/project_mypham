using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository _hoaDonRepository;
        public HoaDonController(IHoaDonRepository hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
        }
        [HttpGet("getallHoaDon")]
        public IActionResult gethoadon()
        {
            var allhoadon = _hoaDonRepository.gethoadon();
            return Ok(allhoadon);
        }
        [HttpGet("detailOrder/{id}")]
        public IActionResult detailOrder(int id)
        {
            var item = _hoaDonRepository.detailOrder(id);
            return Ok(item);
        }
        [HttpGet("ListOrder/{id}")]
        public IActionResult listOrder(int id)
        {
            var item = _hoaDonRepository.ListOrder(id);
            return Ok(item);
        }
        [HttpPost("CapnhatTT")]
        public async Task <IActionResult> capnhatTT([FromForm] int id,[FromForm] int trangthai)
         {
            
            var result = await _hoaDonRepository.CapNhatTT(id, trangthai);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("baocao")]
        public IActionResult baocaodoanhthu()
        {
            var result = _hoaDonRepository.baocaodoanhthu();
            return Ok(result);
        }

        [HttpGet("choxacnhan")]
        public IActionResult choxacnhan()
        {
            var result = _hoaDonRepository.getchoxacnhan();
            return Ok(result);
        }
        [HttpPost("xacnhanall")]
        public IActionResult xacnhanAll()
        {
            var xacnhan = _hoaDonRepository.xacnhandonhang();
            return Ok(xacnhan);
        }

    }
}
