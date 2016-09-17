using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class KampanyaController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/Kampanya
        public ActionResult List()
        {
            IEnumerable<Kampanya> kampanya = context.Kampanya.ToList();
            return View(kampanya);

        }
        public ActionResult New()
        {

            var marka = context.Markalar.Select(x => new SelectListItem
            {

                Text = x.MarkaAdi,
                Value = x.Id.ToString()

            }

                );
            var urun = context.UrunDetaylari.Select(x => new SelectListItem
            {
                Text = x.model_cins,
                Value = x.Id.ToString()
            });
            var kategori = context.Katagori.Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.Id.ToString()
            });
            ViewData["KategoriId"] = kategori;
            ViewData["MarkaId"] = marka;
            ViewData["UrunId"] = urun;

            return View();

        }
        [HttpPost]
        public ActionResult New(ViewModels.Kampanya Kampanya)
        {

            if (context.Kampanya.Where(y => y.UrunId == context.UrunFiyat.Where(x => x.UrunId == Kampanya.UrunId).FirstOrDefault().Id && y.BitisTarihi > System.DateTime.Now).Count() == 0)
            {
                Kampanya Kampanyadb = new Kampanya();
                UrunDetaylari Urundb = new UrunDetaylari();
                Urundb = context.UrunDetaylari.Where(x => x.Id == Kampanya.UrunId).FirstOrDefault();
                Kampanyadb.UrunFiyat = Urundb.UrunFiyat.SingleOrDefault();
                Kampanyadb.UrunId = Urundb.Id;
                Kampanyadb.IndrimOranı = Kampanya.IndirimOranı;
                Kampanyadb.Acıklama = Kampanya.Aciklama;
                Kampanyadb.BaslangıcTarihi = Kampanya.BaslangicTarihi;
                Kampanyadb.BitisTarihi = Kampanya.BitisTarihi;
                context.Kampanya.Add(Kampanyadb);
                context.SaveChanges();
            }


            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            Kampanya Kampanya = context.Kampanya.Find(id);
            context.Kampanya.Remove(Kampanya);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Edit(int id)
        {
            Kampanya kampanya = context.Kampanya.Where(x => x.Id == id).SingleOrDefault();
            return View(new ViewModels.Kampanya()
            {
                Aciklama = kampanya.Acıklama,
                Id = kampanya.Id,
                BaslangicTarihi = kampanya.BaslangıcTarihi,
                BitisTarihi = kampanya.BitisTarihi,
                IndirimOranı = Convert.ToInt32(kampanya.IndrimOranı),
                KategoriId = kampanya.UrunFiyat.UrunDetaylari.Urunler.KategoriId,
                UrunId = kampanya.UrunId,
                MarkaId = kampanya.UrunFiyat.UrunDetaylari.Urunler.MarkaId

            });
        }
        [HttpPost]
        public ActionResult Edit(ViewModels.Kampanya Kampanya)
        {
            Kampanya Kampanyadb = context.Kampanya.Where(x=>x.Id==Kampanya.Id).SingleOrDefault();
                   
            Kampanyadb.UrunId = Kampanya.UrunId;
            Kampanyadb.IndrimOranı = Kampanya.IndirimOranı;
            Kampanyadb.Acıklama = Kampanya.Aciklama;
            Kampanyadb.BaslangıcTarihi = Kampanya.BaslangicTarihi;
            Kampanyadb.BitisTarihi = Kampanya.BitisTarihi;
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}