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
        public decimal FiyatHesap(decimal alıs, float karOranı, float kdvOranı, float indirimOranı)
        {
            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            decimal kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            decimal fiyat = kar + kdv + alıs;
            decimal indirim = fiyat * Convert.ToDecimal(indirimOranı) / 100;
            decimal indrimlifiyat = fiyat - indirim;
            return indrimlifiyat;

        }
        public decimal FiyatHesap(decimal alıs, float karOranı, float kdvOranı)
        {

            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            decimal kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            decimal fiyat = kar + kdv + alıs;

            return fiyat;

        }

        public List<DigerUrunler> KampanyalıUrn(int page)
        {
            List<DigerUrunler> b = new List<DigerUrunler>();

            var currentPosts = context.Kampanya.Where(p => p.BitisTarihi > DateTime.Now).OrderByDescending(p => p.BaslangıcTarihi)
                .Skip((page - 1) * postsPerPage)
                .Take(postsPerPage).ToList();
            DigerUrunler urrun = new DigerUrunler();
            foreach (var _urun in currentPosts)
            {
                urrun.Fiyat = FiyatHesap(_urun.UrunFiyat.AlisFiyati, _urun.UrunFiyat.KarOranı, _urun.UrunFiyat.KdvOrani, _urun.IndrimOranı);
                MemoryStream ms = new MemoryStream(_urun.UrunFiyat.UrunDetaylari.resim, 0, _urun.UrunFiyat.UrunDetaylari.resim.Length);
                ms.Write(_urun.UrunFiyat.UrunDetaylari.resim, 0, _urun.UrunFiyat.UrunDetaylari.resim.Length);
                WebImage image = new WebImage(ms);
                image.Resize(484, 441, false);
                var upload = "~\\images\\Database\\" + _urun.UrunFiyat.UrunId + 484 + 441;
                urrun.ResimYolu = "/images/Database/" + _urun.UrunFiyat.UrunId + 484 + 441 + "." + image.ImageFormat;
                image.Save(upload);
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