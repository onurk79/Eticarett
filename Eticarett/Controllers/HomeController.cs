using System.Web.Mvc;
using Eticarett.Models;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.IO;
using Eticarett.ViewModels;
using System.Web.Helpers;
using Eticarett.Infrastructure;


namespace Eticarett.Controllers
{
    public class HomeController : Controller
    {

        private static int postsPerPage = 3;
        private Entitie context = new Entitie();
        public ActionResult Index(int page = 1)
        {
           
            List<Marka> _markalist = new List<Marka>();
            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                _marka.Id = marka.Id;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                _markalist.Add(_marka);
                ImageLoad Image = new ImageLoad(marka.MarkaLogo, marka.Id, 30, 50);
                _marka.imagePath = Image.ImagePath;
            }
            var totalPostCount = context.Kampanya.Count();
            PageDataForData KampanyalıUrun = new PageDataForData(page, postsPerPage,true);
            return View(new KampanyalıUrunler()
            {
                kampanyalıUrunler = new PageData<ViewModels.Urun>(KampanyalıUrun.Urunler, totalPostCount, page, postsPerPage),
                Marka = _markalist,
                Kategori = context.Katagori.ToList(),
                Page = page
            });
        }

        public ActionResult List(int page = 1 )
        {
            List<Marka> _markalist = new List<Marka>();
            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                _marka.Id = marka.Id;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                _markalist.Add(_marka);
                ImageLoad Image = new ImageLoad(marka.MarkaLogo, marka.Id, 30, 50);
                _marka.imagePath = Image.ImagePath;
            }
            var totalPostCount = context.UrunDetaylari.Count();
            PageDataForData Urun = new PageDataForData(page, postsPerPage, false);
            return View(new ViewModels.Urunler()
            {
                UrunlerList = new PageData<ViewModels.Urun>(Urun.Urunler, totalPostCount, page, postsPerPage),
                Marka = _markalist,
                Kategori = context.Katagori.ToList(),
                Page = page
            });
        }
        [HttpPost]
        public ActionResult List( ViewModels.Urunler id,int ids, bool kampanya, int page)
        {
            List<Marka> _markalist = new List<Marka>();
            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                _marka.Id = marka.Id;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                _markalist.Add(_marka);
                ImageLoad Image = new ImageLoad(marka.MarkaLogo, marka.Id, 30, 50);
                _marka.imagePath = Image.ImagePath;
            }
            if (id.Markamı)
            {
                var totalPostCount = context.UrunDetaylari.Where(x => x.Urunler.Markalar.Id == id.id).Count();
                PageDataForData Urun = new PageDataForData(id.Page, postsPerPage, id.id,id.Markamı);
                return View(new ViewModels.Urunler()
                {
                    UrunlerList = new PageData<ViewModels.Urun>(Urun.Urunler, totalPostCount, id.Page, postsPerPage),
                    Marka = _markalist,
                    Kategori = context.Katagori.ToList(),
                    Page = id.Page
                });
            }
            else
            {
                var totalPostCount = context.UrunDetaylari.Where(x => x.Urunler.Katagori.Id == id.id).Count();
                PageDataForData Urun = new PageDataForData(id.Page, postsPerPage,id.id,id.Markamı);
                return View(new ViewModels.Urunler()
                {
                    UrunlerList = new PageData<ViewModels.Urun>(Urun.Urunler, totalPostCount, id.Page, postsPerPage),
                    Marka = _markalist,
                    Kategori = context.Katagori.ToList(),
                    Page = id.Page
                });
            }
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