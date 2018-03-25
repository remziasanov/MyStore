using StoreExample.DataBaseManager;
using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreExample.Controllers
{
    public class PhoneController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            return View();

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PhoneItem phoneItem)
        {
            PhoneItemManager.AddPhone(phoneItem);
            var results = PhoneItemManager.GetPhones();
            return View("../Phone/AddResult");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var onephone = PhoneItemManager.Get(id);
            if (onephone != null)
            {
                return View(onephone);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var onephone = PhoneItemManager.Get(id);
            if (onephone == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                PhoneItemManager.DeletePhone(id);
                var list = PhoneItemManager.GetPhones();
                int pageSize = 3; //количество объектов на странице
                var result2 = list.Skip((1 - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = 1, PageSize = pageSize, TotalItems = list.Count };
                IndexViewModel indexViewModel = new IndexViewModel { PageInfo = pageInfo, Phones = result2 };
                return View("../Home/Index", indexViewModel);
            }
        }
        [HttpGet]
        [HandleError(ExceptionType = typeof( ArgumentException), Master ="Index" ) ]
        public ActionResult Details(Guid id)
        {
            var result = PhoneItemManager.Get(id);
            if (result == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                return View("../Phone/Details", result);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var result = PhoneItemManager.Get(id);
            if (result == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(result);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(PhoneItem phoneItem)
        {
            PhoneItemManager.EditPhone(phoneItem);
            //var result = InstrumentManager.GetInstruments();
            return RedirectToAction("../Home/Index");
        }


    }
}
