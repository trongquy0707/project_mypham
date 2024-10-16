using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Services.ClientServices.Irepository;
using Web_my_pham.Models;
using Newtonsoft.Json;
using Web_my_pham.Data;

namespace Web_my_pham.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShopingCartRepository _shopingCartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MyDbContext _myDbContext;
        public ShoppingCartController(IShopingCartRepository shopingCartRepository, IHttpContextAccessor httpContextAccessor, MyDbContext myDbContext)
        {
            _shopingCartRepository = shopingCartRepository;
            _httpContextAccessor = httpContextAccessor;
            _myDbContext = myDbContext;
        }
        [HttpPost("addToCart")]
        public IActionResult Addtocart([FromForm] int id, [FromForm] int quantity)
        {
            try
            {
                return Ok(_shopingCartRepository.addToCart(id,quantity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet("getcart")]
        public async Task<IActionResult> getcart()
        {
            try
            {
                // Gọi phương thức getCart để lấy giỏ hàng từ session
                var cartItems = await _shopingCartRepository.getCart();

                // Kiểm tra xem có sản phẩm trong giỏ hàng hay không
                if (cartItems == null )
                {
                    Console.WriteLine("Cart is empty, returning empty list.");
                    return Ok(new List<ShoppingCartItem>()); // Trả về giỏ hàng rỗng nếu không có sản phẩm
                }

                
                return Ok(cartItems); // Trả về các sản phẩm trong giỏ hàng
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving cart: {ex.Message}");
                return BadRequest($"Error retrieving cart: {ex.Message}");
            }
        }
        [HttpDelete("XoaSP/{id}")]
        public async Task<IActionResult> xoasanpham(int id)
        {
            try
            {
                var returnn = await _shopingCartRepository.xoaSanPham(id);
                if (returnn)
                {
                    return Ok("Xoa thanh cong");
                }
                else
                {
                    return NotFound("Không tìm thấy sản phẩm trong giỏ hàng hoặc không có giỏ hàng");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("getsoluong")]
        public IActionResult getquantiy()
        {
            try
            {
                return Ok(_shopingCartRepository.ShowCount());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("updateQuantity")]
        public IActionResult updatequantity([FromForm]int id, [FromForm] int quantity)
        {
            try
            {
                _shopingCartRepository.updateQuantity(id, quantity);
                return Ok("quyzz");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("deleteAllCart")]
        public IActionResult deleteAllcart()
        {
            try
            {
                _shopingCartRepository.deleteAll();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPost("CheckOut")]
        public async Task<IActionResult> checkout([FromForm] OrderViewModel order)
        {
            try
            {
                var result = await _shopingCartRepository.checkout(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

        [HttpGet("returnVnpay")]
        public IActionResult ReturnVnpay(string vnp_Amount, string vnp_TransactionNo, string vnp_TxnRef, string vnp_ResponseCode)
        {
            var tenkhachhang = "";
            var infor = _myDbContext.HOA_DON.FirstOrDefault(m => m.Code == vnp_TxnRef);
            tenkhachhang = infor.TenKhachHang;
            if (vnp_ResponseCode == "00")
            {
                string redirectUrl = $"http://localhost:4200/client/returnVnpay?vnp_Amount={vnp_Amount}&vnp_TransactionNo={vnp_TransactionNo}&vnp_TxnRef={vnp_TxnRef}&customerName={Uri.EscapeDataString(tenkhachhang)}";
                return Redirect(redirectUrl);
            }
            else
            {
                
                string redirectUrl = "http://localhost:4200/client/returnfail";
                return Redirect(redirectUrl);
            }
        }
    }
}
