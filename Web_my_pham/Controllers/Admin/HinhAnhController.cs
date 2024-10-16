using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Models;
using Web_my_pham.Services.AdminServices;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HinhAnhController : ControllerBase
    {
        private IAnhSanPhamRepository _anhSanPhamRepository;
        public HinhAnhController(IAnhSanPhamRepository anhSanPhamRepository)
        {
            _anhSanPhamRepository = anhSanPhamRepository;
        }
        [HttpGet("getall/{id}")]
        public IActionResult getall(int id)
        {
            try
            {
                return Ok(_anhSanPhamRepository.getall(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("themmoianh/{idsanpham}")]
        public async Task<IActionResult> themhinhanh(int idsanpham,[FromForm] HinhAnhModels obj)
        {
            try
            {
                var resutl = await (_anhSanPhamRepository.themanh(idsanpham, obj));
                return Ok(resutl);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("xoaanh/{idanh}")]
        public IActionResult xoanh(int idanh)
        {
            try
            {
                _anhSanPhamRepository.xoaanh(idanh);
                return Ok("Xóa ảnh thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("xoaall/{idsanpham}")]
        public IActionResult xoaall(int idsanpham)
        {
            try
            {
                _anhSanPhamRepository.xoaall(idsanpham);
                return Ok("Xóa ảnh thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
