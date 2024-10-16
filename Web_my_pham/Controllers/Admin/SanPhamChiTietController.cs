using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Services.AdminServices;
using Web_my_pham.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Web_my_pham.Models;
using Microsoft.AspNetCore.Authorization;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamChiTietController : ControllerBase
    {
        private ISanPhamChiTietRepository _sanPhamChiTietRepository;
        
        public SanPhamChiTietController(ISanPhamChiTietRepository sanPhamChiTietRepository)
        {
            _sanPhamChiTietRepository = sanPhamChiTietRepository;
           
        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
            try
            {
                return Ok(_sanPhamChiTietRepository.getall());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("getbyID/{id}")]
        public IActionResult getbyid(int id)
        {
            try
            {
                return Ok(_sanPhamChiTietRepository.getbyId(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
        [HttpPost("suasanpham/{id}")]
        public async Task<IActionResult> suasanphamAsync(int id, [FromForm]SAN_PHAM_CHI_TIET_REQUEST obj)
        {
            try
            {
                var result = await _sanPhamChiTietRepository.suasanpham(id,obj);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
         
        }
        [HttpDelete("xoasanpham/{id}")]
        public IActionResult xoasanpham(int id)
        {
            try
            {
                _sanPhamChiTietRepository.xoasanpham(id);
                return Ok("Đã xóa sản phẩm");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Lỗi cập nhật cơ sở dữ liệu: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi không xác định: {ex.Message}");
            }
        }
        [HttpPost("isHome/{id}")]
        public IActionResult Ishome(int id)
        {
            try
            {
                _sanPhamChiTietRepository.ishome(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }
        [HttpPost("isSale/{id}")]
        public IActionResult Issale(int id)
        {
            try
            {
                _sanPhamChiTietRepository.isSale(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpPost("themmoitesst")]
        
        public async Task<IActionResult> ThemMoiSanPham( [FromForm]SAN_PHAM_CHI_TIET_REQUEST model)
        {
            try 
            {
                var result = await _sanPhamChiTietRepository.themmoitesst(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




    }
    }

