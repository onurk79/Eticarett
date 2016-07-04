using System.Web.Mvc;
using Eticarett.Models;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Globalization;

namespace Eticarett.Controllers
{
    public class HomeController : Controller
    {
        private Entitie context = new Entitie();
        public ActionResult Index(Resimler photo, HttpPostedFileBase image)
        {
            //photo.ResimYolu = image.ContentType;
            //photo.ResimYolu = "C:/Users/onur/Desktop/Adidas.jpg";
            //photo.KatalogResmi = new byte[image.ContentLength];
            //image.InputStream.Read(photo.KatalogResmi, 0, image.ContentLength);
            //context.Resimler.Add(photo);
            //context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}