using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Models;
using Web_my_pham.Services.AdminServices;
using Web_my_pham.Services.AdminServices.Irepository;

namespace Web_my_pham.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DanhMucSanPhamController : ControllerBase
    {
        private IDanhMucSanPhamRepository _danhMucSanPhamRepository;

        public DanhMucSanPhamController(IDanhMucSanPhamRepository DanhMucSanPhamRepository)
        {
            _danhMucSanPhamRepository = DanhMucSanPhamRepository;
        }

        [HttpGet("getAll")]
        
        public IActionResult getAll()
        {
            try
            {
                return Ok(_danhMucSanPhamRepository.Getall());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("getbyId/{id}")]
        public IActionResult getbyid(int id)
        {
            try
            {
                return Ok(_danhMucSanPhamRepository.GetbyId(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("ThemMoiDanhMuc")]
        public async Task<IActionResult> ThemmoiDanhMuc([FromForm] DanhMucSanPhamModels obj)
        {
            try
            {
                var result = await _danhMucSanPhamRepository.ThemDanhMuc(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("SuaDanhMuc/{id}")]
        public async Task<IActionResult> SuaDanhMuc([FromForm] DanhMucSanPhamModels obj, int id)
        {
            try
            {
                var resutl = await _danhMucSanPhamRepository.SuaDanhMuc(obj, id);
                return Ok(resutl);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi cập nhật danh mục sản phẩm.", details = ex.Message });
            }
        }
        [HttpDelete("XoaDanhMuc/{id}")]
        public IActionResult XoaDanhMuc(int id)
        {
            try
            {
                _danhMucSanPhamRepository.XoaDanhMuc(id);
                return Ok("Xoa Thanh Cong");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi cập nhật danh mục sản phẩm.", details = ex.Message });
            }
        }
    }
}
