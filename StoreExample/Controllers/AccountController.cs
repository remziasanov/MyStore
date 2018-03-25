using StoreExample.DataBaseManager;
using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StoreExample.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = PurchaseManager.LogUser(loginModel);
                if (purchase != null)
                {
                    FormsAuthentication.SetAuthCookie(purchase.Email, true);
                    ViewBag.LoginName = User.Identity.Name.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }



            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = PurchaseManager.AddUser(registerModel);
                if (purchase == null)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином существует ");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(registerModel.Email, true);
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
