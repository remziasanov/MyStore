using PagedList;
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
        [HandleError(ExceptionType = typeof(ArgumentNullException), View = "ExceptionFound")]
        public ActionResult Index(int? page)
        {

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var resultlist = PhoneItemManager.GetPhones();
            var result = resultlist.ToPagedList(pageNumber, pageSize);
            return View(result);

        }
    }
}