using StoreExample.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreExample.Controllers
{
    //контроллер для корзины
    public class CartController : Controller
    {
        //установка сессии для корзины и получение доступа к ней
        private CartManager GetCart()
        {
            CartManager cart = (CartManager)Session["Cart"];
            if (cart == null)
            {
                cart = new CartManager();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}