using StoreExample.DataBaseManager;
using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page =1)
        {
            var result = PhoneItemManager.GetPhones();
            int pageSize = 3; //количество объектов на странице
            var result2 = result.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = result.Count };
            IndexViewModel indexViewModel = new IndexViewModel { PageInfo = pageInfo, Phones = result2 };
            if (page > indexViewModel.PageInfo.TotalPages)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(indexViewModel);
            }
        }
    }
}