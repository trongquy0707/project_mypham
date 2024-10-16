using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using Web_my_pham.Data;
using Web_my_pham.Models;

namespace Web_my_pham.Services.ClientServices.Irepository
{
    public interface IShopingCartRepository
    {
        Task<List<ShoppingCartItem>> getCart();

        Task<SAN_PHAM_CHI_TIET> addToCart(int id, int quantity);

         int  ShowCount();

        Task<bool> xoaSanPham(int id);
        void updateQuantity(int id, int quantity);
        void deleteAll();
        Task<string> checkout(OrderViewModel oderViewModel);

        string CreatePaymentUrl(int TypePaymentVN, string Code, HttpContext context);
        returnVnpay PaymentExecute();

    }
}
