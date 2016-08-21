using System.Web.Mvc;
using Eticarett.Models;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Globalization;
using static Eticarett.ViewModels.Lists;
using System.IO;
using System.Drawing;
using Eticarett.ViewModels;
using System.Web.Helpers;

namespace Eticarett.Controllers
{
    public class HomeController : Controller
    {
        private Entitie context = new Entitie();
        public ActionResult Index()
        {
            MarkaKategori MarkaKategori = new MarkaKategori();
           IList< Urunler> Urunler = context.Urunler.OrderByDescending(p => p.Id).Take(10).ToList();
         
            
          
            List<Marka> _markalist = new List<Marka>();
            MarkaKategori.Kategori = context.Katagori.ToList();
            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                MemoryStream ms = new MemoryStream(marka.MarkaLogo, 0, marka.MarkaLogo.Length);
                ms.Write(marka.MarkaLogo, 0, marka.MarkaLogo.Length);
                WebImage image = new WebImage(ms);
                image.Resize(30, 50, true);
                _marka.Id = marka.Id;
                _marka.Image = image;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                _markalist.Add(_marka);
                var upload = Path.Combine(Server.MapPath("~/images/Database/" + _marka.Id));
                _marka.imagePath = "/images/Database/" + _marka.Id + "." + image.ImageFormat;
                image.Save(upload);
            }
            MarkaKategori.Marka = _markalist;

            return View(MarkaKategori);
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