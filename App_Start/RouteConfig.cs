using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace forumAspMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "login",
                url: "dang-nhap",
                defaults: new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }
            );
                routes.MapRoute(
                name: "register",
                url: "dang-ki",
                defaults: new { controller = "Authentication", action = "Register", id = UrlParameter.Optional }
            );
            //admin
            routes.MapRoute(
             name: "admin home",
             url: "admin/trang-chu",
             defaults: new { controller = "AdminHome", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
