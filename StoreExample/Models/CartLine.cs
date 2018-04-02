using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreExample.Models
{
    // модель товара для корзины
    public class CartLine
    {
        public PhoneItem Phone_cart { get; set; }
        public int Quantity { get; set; } //количество товара одного вида
    }
}