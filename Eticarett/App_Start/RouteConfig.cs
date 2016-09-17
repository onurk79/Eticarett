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
            var namespaces = new[] { typeof(HomesController).Namespace };
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("", "List", new { controller = "Home", action = "List" });
            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Login" });
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" });
            routes.MapRoute("iForgotMyPassword", "iForgotMyPassword", new { controller = "Login", action = "iForgotMyPassword" });
            routes.MapRoute("Details", "Details", new { controller = "Home", action = "Details" });
            routes.MapRoute("Account", "Account", new { controller = "Account", action = "Account" });
            routes.MapRoute("ShoppingCardAdd", "ShoppingCardAdd", new { controller = "Home", action = "ShoppingCardAdd" });
            routes.MapRoute("ShoppingCard", "ShoppingCard", new { controller = "Home", action = "ShoppingCard" });
            routes.MapRoute("CompareListAdd", "CompareListAdd", new { controller = "Home", action = "CompareListAdd" });
        }
    }
}
