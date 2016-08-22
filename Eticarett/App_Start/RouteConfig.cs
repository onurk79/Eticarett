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
            routes.MapRoute("", "Index", new { controller = "Home", action = "Index" });
            routes.MapRoute("Indev", "Index", new { controller = "Login", action = "Index" });
            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Login" });
            routes.MapRoute("Save", "Save", new { controller = "Login", action = "Save" });
            //routes.MapRoute("UrunNew", "New", new { controller = "Urun", action = "New" }, namespaces);
            //routes.MapRoute("HomesList", "List", new { controller = "Homes", action = "List" }, namespaces);
            //routes.MapRoute("KampanyaList", "List", new { controller = "Kampanya", action = "List" }, namespaces);
            //routes.MapRoute("KampanyaNew", "New", new { controller = "Kampanya", action = "New" }, namespaces);
            //routes.MapRoute("UrunFiyatList", "List", new { controller = "UrunFiyat", action = "List" }, namespaces);
            //routes.MapRoute("UrunList", "List", new { controller = "Urun", action = "List" }, namespaces);
            //routes.MapRoute("UrunDetayList", "List", new { controller = "UrunDetay", action = "List" }, namespaces);
            //routes.MapRoute("UrunOzelliklerList", "List", new { controller = "UrunOzellikler", action = "List" }, namespaces);
            //routes.MapRoute("ÜyeList", "List", new { controller = "Üye", action = "List" }, namespaces);
            //routes.MapRoute("BankaList", "List", new { controller = "Banka", action = "List" }, namespaces);
            //routes.MapRoute("KargoList", "List", new { controller = "Kargo", action = "List" }, namespaces);
            //routes.MapRoute("KatagoriList", "List", new { controller = "Katagori", action = "List" }, namespaces);
            //routes.MapRoute("MarkalarList", "List", new { controller = "Markalar", action = "List" }, namespaces);
            //routes.MapRoute("OdemeSecenekleriList", "List", new { controller = "OdemeSecenekleri", action = "List" }, namespaces);
            //routes.MapRoute("OzellikDetayList", "List", new { controller = "OzellikDetay", action = "List" }, namespaces);
            //routes.MapRoute("ResimlerList", "List", new { controller = "Resimler", action = "List" }, namespaces);
            //routes.MapRoute("RollerList", "List", new { controller = "Roller", action = "List" }, namespaces);
            //routes.MapRoute("SepetList", "List", new { controller = "Sepet", action = "List" }, namespaces);
            //routes.MapRoute("SiparisDurumuList", "List", new { controller = "SiparisDurumu", action = "List" }, namespaces);
            //routes.MapRoute("SiparislerList", "List", new { controller = "Siparisler", action = "List" }, namespaces);
            //routes.MapRoute("TaksitlerList", "List", new { controller = "Taksitler", action = "List" }, namespaces);
            //routes.MapRoute("TaksitTaplosuList", "List", new { controller = "TaksitTaplosu", action = "List" }, namespaces);

        }
    }
}
