using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreExample.DataBaseManager
{
    public class Initializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            base.Seed(context);
            context.Roles.Add(new Role { Id = 1, Name = "Admin" });
            context.Roles.Add(new Role { Id = 2, Name = "Purchase" });
            context.Purchases.Add(new Purchase
            {
                Id = Guid.NewGuid(),
                Email = "remziasanov@gmail.com",
                Name = "Admin",
                SurName = "Admin",
                Password = "Admin123456789",
                Phone = "+79788998955",
                Address = "Simferopol, Gorkogo 11",
                IndexPost = "290000",
                RoleId = 1
            });
            context.Phones.Add(new PhoneItem { Id = Guid.NewGuid(), ModelOfPhone = "Iphone X", Description = "Крутой телефон", Category = "Смартфоны", SubCategory = "IOS", Price = 75000, ImgUrl = "" });
            base.Seed(context);
        }
    }
}