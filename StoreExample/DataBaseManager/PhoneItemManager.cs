using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreExample.DataBaseManager
{
    public class PhoneItemManager
    {
        public static List<PhoneItem> GetPhones()
        {
            var result = new List<PhoneItem>();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    result = db.Phones.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка валидации" + ex.Message.ToString());
                    Console.ReadLine();
                    result = null;
                }
            }
            return result;
        }
        public static PhoneItem Get(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var res = db.Phones.ToList();

                foreach (var inst in db.Phones)
                {
                    if (inst.Id == id)
                        return inst;
                }
                return null;
            }
        }
        public static void AddPhone(PhoneItem inst)
        {
            inst.Id = Guid.NewGuid();
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Phones.Add(inst);
                db.SaveChanges();
            }
        }
        public static void DeletePhone(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new PhoneItem ();
                foreach (var item in db.Phones)
                {
                    if (item.Id == id)
                    {
                        temp = item;
                    }

                }
                db.Phones.Remove(temp);
                db.SaveChanges();
            }
        }
        public static void EditPhone(PhoneItem phone)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var phone2 = db.Phones.SingleOrDefault(x => x.Id == phone.Id);
                phone2.ModelOfPhone = phone.ModelOfPhone;

                phone2.Price = phone.Price;
                phone2.Description = phone.Description;
                phone2.ImgUrl = phone.ImgUrl;
                phone2.Category = phone.Category;
                phone2.SubCategory = phone.SubCategory;
                db.SaveChanges();
            }
        }
        public static bool BuyPhone(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                foreach (var inst in db.Phones)
                {
                    if (inst.Id == id)
                        return true;
                }
                return false;
            }
        }
    }
}