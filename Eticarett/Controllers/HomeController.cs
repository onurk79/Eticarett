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


        public List<DigerUrunler> KampanyalıUrn(int page)
        {
            List<DigerUrunler> b = new List<DigerUrunler>();

            var currentPosts = context.Kampanya.Where(p => p.BitisTarihi > DateTime.Now).OrderByDescending(p => p.BaslangıcTarihi)
                .Skip((page - 1) * postsPerPage)
                .Take(postsPerPage).ToList();
            DigerUrunler urrun = new DigerUrunler();
            foreach (var _urun in currentPosts)
            {
                Prince Fiyat = new Prince(_urun.UrunFiyat.AlisFiyati, _urun.UrunFiyat.KarOranı, _urun.UrunFiyat.KdvOrani, _urun.IndrimOranı);
                urrun.Fiyat = Fiyat.Fiyat;
                Image Image = new Image(_urun.UrunFiyat.UrunDetaylari.resim, _urun.UrunFiyat.UrunId, 484, 441);
                urrun.ResimYolu = Image.ImagePath;
                urrun.UrunId = _urun.UrunFiyat.UrunId;
                urrun.UrunAdi = _urun.UrunFiyat.UrunDetaylari.model_cins;
                b.Add(urrun);


            }
            return b;
        }

        private static int postsPerPage = 5;
        private Entitie context = new Entitie();
        public ActionResult Index(int page = 1)
        {
            Lists MarkaKategori = new Lists();
            IList<Urunler> Urunler = context.Urunler.OrderByDescending(p => p.Id).Take(10).ToList();



            List<Marka> _markalist = new List<Marka>();

            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                _marka.Id = marka.Id;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                _markalist.Add(_marka);
                Image Image = new Image(marka.MarkaLogo, marka.Id, 30, 50);
                _marka.imagePath = Image.ImagePath;
            }

            var totalPostCount = context.Kampanya.Count();

            var currentPosts = KampanyalıUrn(page);


            return View(new KampanyalıUrunler()
            {
                kampanyalıUrunler = new PageData<DigerUrunler>(currentPosts, totalPostCount, page, postsPerPage),
                Marka = _markalist,
                Kategori = context.Katagori.ToList()
            });
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