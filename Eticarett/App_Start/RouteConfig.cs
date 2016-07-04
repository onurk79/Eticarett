using Eticarett.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eticarett
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var namespaces = new[] { typeof(HomeController).Namespace };
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("Indev", "Index", new { controller = "Login", action = "Index" }/*, namespaces*/);
            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Login" }/*, namespaces*/);
            routes.MapRoute("Save", "Save", new { controller = "Login", action = "Save" }/*, namespaces*/);
            routes.MapRoute("ekle", "ekle", new { controller = "UrunEkle", action = "ekle" }/*,namespaces*/);
            routes.MapRoute("List", "", new { controller = "Homes", action = "List" }/*, namespaces*/);
            routes.MapRoute("KampanyaList", "", new { controller = "Kampanya", action = "List" }/*, namespaces*/);
            routes.MapRoute("KampanyaNew", "", new { controller = "Kampanya", action = "New" }/*, namespaces*/);
        }
    }
}
