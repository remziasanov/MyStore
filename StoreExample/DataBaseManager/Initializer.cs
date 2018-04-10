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
                Email = "admin@gmail.com",
                Name = "Admin",
                SurName = "Admin",
                Password = "Admin123456789",
                Phone = "+7978000000",
                Address = "Simferopol",
                IndexPost = "290000",
                RoleId = 1
            });
            context.Phones.Add(new PhoneItem { Id = Guid.NewGuid(), ModelOfPhone = "Iphone X",
              Description = "iPhone имеет экран 5,8 дюйма с разрешением 2436х1125 точек и технологией True Tone (настраивает теплоту белого цвета на экране).iPhone X получил оперативную память объемом 3 ГБ и 128 / 256 ГБ встроенной памяти.Кроме того,в гаджете реализована технология беспроводной зарядки благодаря его стеклянному корпусу. ",
              Category = "Смартфоны", SubCategory = "IOS", Price = 75000, ImgUrl = "https://static.svyaznoy.ru/upload/iblock/0f2/iphonex-spgry-34br-34fl-2up-gb-en-screen.jpg/resize/483x483/hq/" });
            context.Phones.Add(new PhoneItem
            {
                Id = Guid.NewGuid(),
                ModelOfPhone = "Iphone X",
                Description = "iPhone имеет экран 5,8 дюйма с разрешением 2436х1125 точек и технологией True Tone (настраивает теплоту белого цвета на экране).iPhone X получил оперативную память объемом 3 ГБ и 128 / 256 ГБ встроенной памяти.Кроме того,в гаджете реализована технология беспроводной зарядки благодаря его стеклянному корпусу. ",
                Category = "Смартфоны",
                SubCategory = "IOS",
                Price = 75000,
                ImgUrl = "https://static.svyaznoy.ru/upload/iblock/0f2/iphonex-spgry-34br-34fl-2up-gb-en-screen.jpg/resize/483x483/hq/"
            });
            context.Phones.Add(new PhoneItem
            {
                Id = Guid.NewGuid(),
                ModelOfPhone = "IPhone 8",
                Description = "iPhone 8 — это, скорее, хороший выбор для обладателей iPhone 6s и более старших моделей. Они, возможно, еще не готовы отдать 1000 долларов за iPhone X, но вполне созрели для 700-долларового iPhone 8 (мы говорим об американских ценах) с максимальной начинкой, лучшей на мобильном рынке камерой и привычным, пускай и порядком поднадоевшим, дизайном",
                Category = "Смартфоны",
                SubCategory = "IOS",
                Price = 60000,
                ImgUrl = "http://gallery.ykt.ru/gals/2017/12/03/mobil/2501539_0.png"
            });
            context.Phones.Add(new PhoneItem
            {
                Id = Guid.NewGuid(),
                ModelOfPhone = "Iphone X",
                Description = "iPhone имеет экран 5,8 дюйма с разрешением 2436х1125 точек и технологией True Tone (настраивает теплоту белого цвета на экране).iPhone X получил оперативную память объемом 3 ГБ и 128 / 256 ГБ встроенной памяти.Кроме того,в гаджете реализована технология беспроводной зарядки благодаря его стеклянному корпусу. ",
                Category = "Смартфоны",
                SubCategory = "IOS",
                Price = 75000,
                ImgUrl = "https://static.svyaznoy.ru/upload/iblock/0f2/iphonex-spgry-34br-34fl-2up-gb-en-screen.jpg/resize/483x483/hq/"
            });

            base.Seed(context);
        }
    }
}