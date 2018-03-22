using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreExample.DataBaseManager
{
    public class PurchaseManager
    {
        public static Purchase AddUser(RegisterModel user)
        {
            Purchase purchase = new Purchase();
            Purchase purchase2 = new Purchase();
            using (DataBaseContext db = new DataBaseContext())
            {
                purchase2 = db.Purchases.FirstOrDefault(u => u.Email == user.Email);
            }
            if (purchase2 == null)
            {
                purchase.Id = Guid.NewGuid();
                purchase.Name = user.Name;
                purchase.SurName = user.SurName;
                purchase.Email = user.Email;
                purchase.Password = user.Password;
                purchase.Phone = user.Phone;
                purchase.Address = user.Address;
                purchase.IndexPost = user.IndexPost;
                purchase.RoleId = 2;
                // создаем нового пользователя
                using (DataBaseContext db = new DataBaseContext())
                {
                    db.Purchases.Add(purchase);
                    db.SaveChanges();
                }
                return purchase;
            }
            else
            { //Пользователь с таким Email существует
                //возращается пустой покупатель
                return purchase;
            }
        }
        public static Purchase LogUser(LoginModel loguser)
        {
            // поиск пользователя в бд
            Purchase user = null;
            using (DataBaseContext db = new DataBaseContext())
            {
                user = db.Purchases.FirstOrDefault(u => u.Email == loguser.Email && u.Password == loguser.Password);
            }
            return user;
        }
    }
}