using System.Web.Mvc;
using Eticarett.Models;
using System.Linq;
using System.Collections.Generic;
using Eticarett.ViewModels;
using Eticarett.Infrastructure;
using System.Web;
using System;

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
                _marka.imagePath = new ImageLoad(marka.MarkaLogo, marka.Id, 30, 50).ImagePath;

            }
            var totalPostCount = context.Kampanya.Count();
            PageDataForData KampanyalıUrun = new PageDataForData(page, postsPerPage, true);
            return View(new KampanyalıUrunler()
            {
                kampanyalıUrunler = new PageData<ViewModels.Urun>(KampanyalıUrun.Urunler, totalPostCount, page, postsPerPage),
                Marka = _markalist,
                Kategori = context.Katagori.ToList(),
                Page = page
            });
        }
        public ActionResult List(int id = 0, bool markamı = false, int page = 1)
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
            if (id == 0)
            {

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
            else
            {

                if (markamı)
                {
                    var totalPostCount = context.UrunDetaylari.Where(x => x.Urunler.Markalar.Id == id).Count();
                    PageDataForData Urun = new PageDataForData(page, postsPerPage, id, markamı);
                    return View(new ViewModels.Urunler()
                    {
                        UrunlerList = new PageData<ViewModels.Urun>(Urun.Urunler, totalPostCount, page, postsPerPage),
                        Marka = _markalist,
                        Kategori = context.Katagori.ToList(),
                        Page = page
                    });
                }
                else
                {
                    var totalPostCount = context.UrunDetaylari.Where(x => x.Urunler.Katagori.Id == id).Count();
                    PageDataForData Urun = new PageDataForData(page, postsPerPage, id, markamı);
                    return View(new ViewModels.Urunler()
                    {
                        UrunlerList = new PageData<ViewModels.Urun>(Urun.Urunler, totalPostCount, page, postsPerPage),
                        Marka = _markalist,
                        Kategori = context.Katagori.ToList(),
                        Page = page
                    });
                }
            }
        }
        private static bool durum = true;
        public ActionResult ShoppingCardAdd(int id, string urll)
        {

            if (durum || Session.Count == 0) { Session.Add("count", 1); durum = false; }

            else
            {
                string count = Session["count"].ToString();
                count = (Convert.ToInt32(count) + 1).ToString();
                Session.Add("count", count);
            }

            ViewModels.Sepet sepet = new ViewModels.Sepet();

            if (Session[id.ToString()] == null)
            {
                sepet.Adet = 1;
            }
            else
            {
                ViewModels.Sepet _sepet = new ViewModels.Sepet();
                _sepet = (ViewModels.Sepet)Session[id.ToString()];
                sepet.Adet = _sepet.Adet + 1;
            }
            sepet.Id = id;
            UrunDetaylari Urun = context.UrunDetaylari.Where(x => x.Id == id).FirstOrDefault();
            sepet.UrunAdi = Urun.model_cins;
            sepet.Kdv = new Prince(Urun.UrunFiyat.FirstOrDefault().AlisFiyati,Urun.UrunFiyat.FirstOrDefault().KarOranı,Urun.UrunFiyat.FirstOrDefault().KdvOrani).Kdv;
            sepet.ResimYolu = new ImageLoad(Urun.resim, id, 110, 110).ImagePath;

            if (Urun.UrunFiyat.FirstOrDefault().Kampanya.Count == 0)
                sepet.Fiyat = new Prince(Urun.UrunFiyat.FirstOrDefault().AlisFiyati, Urun.UrunFiyat.FirstOrDefault().KarOranı, Urun.UrunFiyat.FirstOrDefault().KdvOrani).Fiyat;
            else
                sepet.Fiyat = new Prince(Urun.UrunFiyat.FirstOrDefault().AlisFiyati, Urun.UrunFiyat.FirstOrDefault().KarOranı, Urun.UrunFiyat.FirstOrDefault().KdvOrani, Urun.UrunFiyat.FirstOrDefault().Kampanya.FirstOrDefault().IndrimOranı).Fiyat;
            sepet.ToplamFiyat = string.Format("{0:0,0.00}", (Convert.ToDecimal(sepet.Fiyat) * sepet.Adet));
            Session[id.ToString()] = sepet;
            return Redirect(urll);
        }
        public ActionResult ShoppingCard()
        {
            return View();
        }
        string Fiyat;
        public ActionResult Details(int id)
        {

            List<Marka> _markalist = new List<Marka>();
            IList<Markalar> Markalar = context.Markalar.ToList();
            foreach (var marka in Markalar)
            {
                ViewModels.Marka _marka = new ViewModels.Marka();
                _marka.Id = marka.Id;
                _marka.MarkaAcıklmasi = marka.MarkaAcıklmasi;
                _marka.MarkaAdi = marka.MarkaAdi;
                ImageLoad Image = new ImageLoad(marka.MarkaLogo, marka.Id, 30, 50);
                _marka.imagePath = Image.ImagePath;
                _markalist.Add(_marka);

            }

            UrunFiyat urun = context.UrunFiyat.Where(x => x.UrunId == id).SingleOrDefault();
            if (urun.Kampanya == null)
            {
                Prince prince = new Prince(urun.AlisFiyati, urun.KarOranı, urun.KdvOrani);
                Fiyat = prince.Fiyat;
            }
            else
            {
                foreach (var i in urun.Kampanya)
                {
                    Prince prince = new Prince(urun.AlisFiyati, urun.KarOranı, urun.KdvOrani, i.IndrimOranı);
                    Fiyat = prince.Fiyat;
                }
            }
            return View(new Detay()
            {
                Marka = _markalist,
                Kategori = context.Katagori.ToList(),
                detay = context.OzellikDetay.Where(x => x.UrunId == id).SingleOrDefault(),
                Fiyat = Fiyat

            });
        }
        [HttpPost]
        public SepetToplam CardUpdate()
        {
            SepetToplam SepetToplam = new SepetToplam();
            for (int i = 1; i < Session.Count; i++)
            {
                ViewModels.Sepet sepet;
                sepet = (ViewModels.Sepet)(Session[Session.Keys[i].ToString()]);
                SepetToplam.Toplam += Convert.ToDecimal( sepet.ToplamFiyat);
                SepetToplam.Kdv += sepet.Kdv;
                SepetToplam.Indirim += sepet.Indirim;
                SepetToplam.Sepet += sepet.Sepett;
            }
            return SepetToplam;
        }

    }
}