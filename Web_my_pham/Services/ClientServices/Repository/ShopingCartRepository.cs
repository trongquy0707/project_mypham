using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.ClientServices.Irepository;
using Web_my_pham.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;
using Web_my_pham.Models.Payments;

namespace Web_my_pham.Services.ClientServices.Repository
{
        public class ShopingCartRepository : IShopingCartRepository
    {
        private readonly MyDbContext _myDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _confi;
        public ShopingCartRepository(MyDbContext myDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _myDbContext = myDbContext;
            _confi = config;
        }
        public async Task<SAN_PHAM_CHI_TIET> addToCart(int id, int quantity)
        {
            try
            {
                SAN_PHAM_CHI_TIET checkSp = _myDbContext.SAN_PHAM_CHI_TIET.FirstOrDefault(x => x.MaSP == id);
                if (checkSp != null)
                {
                    var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
                   
                    ShoppingCart cart;

                    if (!string.IsNullOrEmpty(sessionCart))
                    {
                        cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
                    }
                    else
                    {
                        cart = new ShoppingCart();
                     }
                    ShoppingCartItem item = new ShoppingCartItem
                    {
                        IdSanPham = checkSp.MaSP,
                        TenSanPham = checkSp.TenSanPham,
                        AnhSanPham = checkSp.HinhAnhChinh,
                        SoLuong = quantity,
                        GiaSanPham = (decimal)(checkSp.GiaSale > 0 ? checkSp.GiaSale : checkSp.GiaGoc)
                    };
                     
                    item.TongGia = item.SoLuong * item.GiaSanPham;
                    cart.AddtoCart(item, quantity);

                    var updatedCart = JsonConvert.SerializeObject(cart);
                   

                    _httpContextAccessor.HttpContext.Session.SetString("Cart", updatedCart);
                    return checkSp;

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product to cart: {ex.Message}");
            }
        }

        public string CreatePaymentUrl(int TypePaymentVN, string orderCode, HttpContext context)
            {
            try
            {
                if (string.IsNullOrEmpty(orderCode))
                {
                    throw new ArgumentNullException(nameof(orderCode), "Order code is null or empty.");
                }

                var order = _myDbContext.HOA_DON.FirstOrDefault(x => x.Code == orderCode);
                if (order == null)
                {
                    throw new Exception("Order not found with the provided code.");
                }
                var tick = DateTime.Now.Ticks.ToString();
                var Price = (long)order.TongTien * 100;
                var vnpay = new VnPayLibrary();
                if (string.IsNullOrEmpty(_confi["VnPay:Version"]) ||
                     string.IsNullOrEmpty(_confi["VnPay:Command"]) ||
                     string.IsNullOrEmpty(_confi["VnPay:vnp_TmnCode"]))
                {
                    throw new Exception("Configuration values for VnPay are missing.");
                }
                 vnpay.AddRequestData("vnp_Version", _confi["VnPay:Version"]);
                vnpay.AddRequestData("vnp_Command", _confi["VnPay:Command"]);
                vnpay.AddRequestData("vnp_TmnCode", _confi["VnPay:vnp_TmnCode"]);
                vnpay.AddRequestData("vnp_Amount", Price.ToString()); //Số tiền thanh toán. Số tiền không 
                if (TypePaymentVN == 1)
                {
                    vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
                }
                else if (TypePaymentVN == 2)
                {
                    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                }
                else if (TypePaymentVN == 3)
                {
                    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                }


                vnpay.AddRequestData("vnp_CreateDate", order.NgayMua.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", _confi["VnPay:CurrCode"]);
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
                vnpay.AddRequestData("vnp_Locale", _confi["VnPay:Locale"]);

                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toán cho đơn hàng:" + order.MaHD);
                vnpay.AddRequestData("vnp_OrderType", "other"); 
                vnpay.AddRequestData("vnp_ReturnUrl", _confi["VnPay:PaymentBackReturnUrl"]);
                vnpay.AddRequestData("vnp_TxnRef", orderCode); 
                if (string.IsNullOrEmpty(_confi["VnPay:BaseUrl"]) || string.IsNullOrEmpty(_confi["VnPay:vnp_HashSecret"]))
                {
                    throw new Exception("VnPay base URL or hash secret is missing.");
                }
                var paymentUrl = vnpay.CreateRequestUrl(_confi["VnPay:BaseUrl"], _confi["VnPay:vnp_HashSecret"]);

                return paymentUrl;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<string> checkout(OrderViewModel order)
        {
            try
            {
                var paymentUrl = "";
                if (order != null)
                {

                    var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
                    ShoppingCart cart;

                    if (!string.IsNullOrEmpty(sessionCart))
                    {
                        cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
                    }
                    else
                    {
                        cart = new ShoppingCart();
                    }
                    if (cart != null)
                    {
                        HOA_DON hoadon = new HOA_DON();
                        hoadon.TenKhachHang = order.TenKhachHang;
                        hoadon.SoDienThoai = order.SoDienThoai;
                        hoadon.Email = order.Email;
                        hoadon.ThanhPho = order.ThanhPho;
                        hoadon.Quan_Huyen = order.Quan_Huyen;
                        hoadon.Xa_Phuong = order.Xa_Phuong;
                        hoadon.Ghi_Chu = order.Ghi_Chu;
                        hoadon.Status = 1;
                        cart.Items.ForEach(x => hoadon.HOA_DON_CHI_TIET.Add(
                            new HOA_DON_CHI_TIET
                            {
                                MaSP = x.IdSanPham,
                                SoLuongMua = x.SoLuong,
                                GiaBan = (float)x.GiaSanPham,
                            }
                            ));
                        hoadon.TongTien = (float)cart.Items.Sum(x => (x.GiaSanPham * x.SoLuong));
                        hoadon.Thanh_Toan = order.Thanh_Toan;
                        hoadon.NgayMua = DateTime.Now;
                        Random rd = new Random();
                        hoadon.Code = "HD" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                        await _myDbContext.HOA_DON.AddAsync(hoadon);
                        await _myDbContext.SaveChangesAsync();
                        cart.ClearCart();
                        deleteAll();
                        var updateCart = JsonConvert.SerializeObject(cart);
                     
                        _httpContextAccessor.HttpContext.Session.SetString("Cart", updateCart);
                        
                        if (order.Thanh_Toan == 0)
                        {
                           paymentUrl =   CreatePaymentUrl(order.Thanh_Toan, hoadon.Code, _httpContextAccessor.HttpContext);
                            Console.WriteLine($"Payment URL: {paymentUrl}");
                            return paymentUrl;
                        }
                    }
                }
                return paymentUrl;


            }
            catch (Exception ex)
            {
                throw;
            }


        }
       
      
        public void deleteAll()
        {
            try
            {
                var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
               
                ShoppingCart cart;
                if (!string.IsNullOrEmpty(sessionCart))
                {

                    cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);


                    cart.ClearCart();
                    var updateCart = JsonConvert.SerializeObject(cart);
                   
                    _httpContextAccessor.HttpContext.Session.SetString("Cart", updateCart);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ShoppingCartItem>> getCart()
        {
            try
            {
                // Lấy cookie từ request
                var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
                Console.WriteLine($"Session Cart: {sessionCart}"); // Ghi log sessionCart

                // Nếu cookie giỏ hàng không tồn tại hoặc rỗng, trả về danh sách rỗng
                if (string.IsNullOrEmpty(sessionCart))
                {
                    return new List<ShoppingCartItem>();
                }

                // Deserialize cookie thành đối tượng ShoppingCart
                ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
                Console.WriteLine($"Cart Items Count: {cart.Items.Count}");
                // Trả về danh sách sản phẩm trong giỏ hàng
                return cart.Items;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving cart: {ex.Message}");
            }
        }



        public int ShowCount()
        {
            var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
            
            ShoppingCart cart;

            int dem = 0;
            if (!string.IsNullOrEmpty(sessionCart))
            {
                cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
                dem = cart.Items.Count;

            }
            return dem;
        }

        public void updateQuantity(int id, int quantity)
        {
            var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
           
            ShoppingCart cart;
            if (!string.IsNullOrEmpty(sessionCart))
            {
                cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
                cart.UpdateQuantity(id, quantity);

                var updatecart = JsonConvert.SerializeObject(cart);
             
                _httpContextAccessor.HttpContext.Session.SetString("Cart", updatecart);
            }


        }

        public async Task<bool> xoaSanPham(int id)
        {
            try
            {
                var sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");
               
                ShoppingCart cart;
                if (!string.IsNullOrEmpty(sessionCart))
                {

                    cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);

                    var timkiem = cart.Items.FirstOrDefault(m => m.IdSanPham == id);
                    if (timkiem != null)
                    {
                        cart.Remove(id);
                        var updateCart = JsonConvert.SerializeObject(cart);
                       
                        _httpContextAccessor.HttpContext.Session.SetString("Cart", updateCart);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public returnVnpay PaymentExecute()
        {  ////https://localhost:44353/api/ShoppingCart/returnVnpay
            try
            {
                var query = _httpContextAccessor.HttpContext.Request.Query;
                returnVnpay orderResult = new returnVnpay();
                if (query.Count > 0)
                {
                    string vnp_HashSecret = _confi["VnPay:vnp_HashSecret"]; //Chuoi bi mat
                    VnPayLibrary vnpay = new VnPayLibrary();


                    foreach (string s in query.Keys)
                    {
                        //get all querystring data
                        if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                        {
                            vnpay.AddResponseData(s, query[s]);
                        }
                    }
                    string orderCode = Convert.ToString(vnpay.GetResponseData("vnp_TxnRef"));
                    long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                    string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                    string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                    String vnp_SecureHash = query["vnp_SecureHash"];
                    String TerminalID = query["vnp_TmnCode"];
                    long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                    String bankCode = query["vnp_BankCode"];

                    bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                    if (checkSignature)
                    {
                        if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                        {
                            var itemOrder = _myDbContext.HOA_DON.FirstOrDefault(x => x.Code == orderCode);
                            if (itemOrder != null)
                            {
                                itemOrder.Status = 2;//đã thanh toán
                                _myDbContext.HOA_DON.Attach(itemOrder);
                                _myDbContext.Entry(itemOrder).State = EntityState.Modified;
                                _myDbContext.SaveChanges();
                            }
                            
                            orderResult.Message = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                            orderResult.IsSuccess = true;
                            orderResult.Amount = vnp_Amount;
                            orderResult.TenKhachHang = itemOrder.TenKhachHang;
                          
                        }
                        else
                        {
                          
                            orderResult.Message = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        
                        }
                    }
                }
          
                return orderResult;
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
