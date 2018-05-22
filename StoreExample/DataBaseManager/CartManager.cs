using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreExample.DataBaseManager
{
    // метод для работы с корзиной
    public class CartManager
    {
        // абстрактная корзина или список товаров
        private List<CartLine> lineCollection = new List<CartLine>();

        // метод для добавления товара в корзину
        public void AddItem(PhoneItem phone, int quantity)
        {
            CartLine line = lineCollection.SingleOrDefault( x=> x.Phone_cart.Id == phone.Id);
            //если товар не найден в корзинеб то он добавляется туда
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Phone_cart = phone,
                    Quantity = quantity
                });
            }
            //если найден то увеличивается количество
            else
            {
                if(quantity > 0)
                {
                    line.Quantity += quantity;
                }
                else
                {
                    if(quantity < 0 && line.Quantity!=1)
                    {
                        line.Quantity += quantity;
                    }
                }
                    
            }
        }
        //метод для удаления товара из корзины
        public void RemoveLine(PhoneItem phone)
        {
            lineCollection.RemoveAll(l => l.Phone_cart.Id == phone.Id);
        }
        //метод для подсчета общей стоимости покупок
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Phone_cart.Price * e.Quantity);
        }
        //метод для очистки корзины
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}