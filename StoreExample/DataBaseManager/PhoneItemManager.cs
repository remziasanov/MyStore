using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public static async Task<List<PhoneItem>> GetPhonesAsync()
        {
            var result = new List<PhoneItem>();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    result = await db.Phones.ToListAsync();
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
        public static async Task<PhoneItem> GetAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var res = await db.Phones.ToListAsync();
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
        public static async Task<bool> AddInstrumentAsync(PhoneItem phoneItem)
        {
            if (phoneItem != null)
            {
                phoneItem.Id = Guid.NewGuid();
                using (DataBaseContext db = new DataBaseContext())
                {
                    db.Phones.Add(phoneItem);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DeletePhone(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new PhoneItem();
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
        public static async Task<bool> DeletePhoneAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new PhoneItem();
                foreach (var item in db.Phones)
                {
                    if (item.Id == id)
                    {
                        temp = item;
                    }
                }
                db.Phones.Remove(temp);
                await db.SaveChangesAsync();
                return true;
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
        public static async Task<bool> EditPhoneAsync(PhoneItem phoneItem)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var phoneItem2 = await db.Phones.SingleOrDefaultAsync(x => x.Id == phoneItem.Id);
                if (phoneItem2 != null)
                {
                    phoneItem2.ModelOfPhone = phoneItem.ModelOfPhone;
                    phoneItem2.Price = phoneItem.Price;
                    phoneItem2.Description = phoneItem.Description;
                    phoneItem2.ImgUrl = phoneItem.ImgUrl;
                    phoneItem2.Category = phoneItem.Category;
                    phoneItem2.SubCategory = phoneItem.SubCategory;
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
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
        public static List<PhoneItem>PhoneSearch(string name)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
              var result = db.Phones.Where(p => p.ModelOfPhone.Contains(name)).ToList();
                return result;
            }
        }
    }
}