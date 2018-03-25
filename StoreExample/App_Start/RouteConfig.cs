using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoreExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(null, "Store/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", controller = "Home",id = UrlParameter.Optional });

            //routes.MapRoute("MyRoute", "{controller}/{action}",
            //    defaults: new { action = "Index", controller = "Home" });
            //routes.MapRoute("Default", "Shop/{action}/{id}",
            //    defaults: new { action = "Index", controller = "Home", id = UrlParameter.Optional });
        }
    }
}
       
