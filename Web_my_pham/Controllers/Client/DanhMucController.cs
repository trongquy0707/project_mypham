using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.ClientServices.Irepository;
using Web_my_pham.Services.ClientServices.Repository;

namespace Web_my_pham.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucRepositoryClient _danhMucRepositoryClient;
        public DanhMucController(IDanhMucRepositoryClient danhMucRepositoryClient)
        {
            _danhMucRepositoryClient = danhMucRepositoryClient;
        }
        [HttpGet("getallCategory")]
        public IActionResult getallCategory()
        {
            try
            {
                return Ok(_danhMucRepositoryClient.getall());

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
