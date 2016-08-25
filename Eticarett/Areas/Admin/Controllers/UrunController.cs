using Eticarett.Infrastructure;
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
    public class UrunController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/Urun
        public ActionResult List()
        {
            IEnumerable<Urunler> urunler = context.Urunler.ToList();

            return View(urunler);
        }
        public ActionResult New()
        {
            var marka = context.Markalar.Select(x => new SelectListItem
            {

                Text = x.MarkaAdi,
                Value = x.Id.ToString()

            });

            var kategori = context.Katagori.Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.Id.ToString()
            });
            ViewData["KategoriId"] = kategori;
            ViewData["MarkaId"] = marka;
            return View();
        }
        [HttpPost]
        public ActionResult New (Urunler Urun)
        {
            if(context.Urunler.Where(x=>x.KategoriId==Urun.KategoriId&&x.MarkaId==Urun.MarkaId).Count()==0)
            {
                var markaAdi = context.Markalar.Where(x => x.Id == Urun.MarkaId).SingleOrDefault().MarkaAdi;
                var kategoriAdi = context.Katagori.Where(x => x.Id == Urun.KategoriId).SingleOrDefault().KategoriAdi;
                Urun.Acıklama = markaAdi.ToString() + kategoriAdi.ToString();
                context.Urunler.Add(Urun);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }
        
        public ActionResult Delete(int id)
        {
            Urunler Urun = context.Urunler.Find(id);
            context.Urunler.Remove(Urun);
            context.SaveChanges();
           return RedirectToAction("list");
        }
       public ActionResult Edit(int id)
        {
            var marka = context.Markalar.Select(x => new SelectListItem
            {

                Text = x.MarkaAdi,
                Value = x.Id.ToString()

            });

            var kategori = context.Katagori.Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.Id.ToString()
            });
            ViewData["KategoriId"] = kategori;
            ViewData["MarkaId"] = marka;
            
            return View( new Urunler{ Id=id});
        }
        [HttpPost]
        public ActionResult Edit(Urunler _Urun)
        { Urunler Urun =context.Urunler.Find(_Urun.Id);
            var markaAdi = context.Markalar.Where(x => x.Id == _Urun.MarkaId).SingleOrDefault().MarkaAdi;
            var kategoriAdi = context.Katagori.Where(x => x.Id == _Urun.KategoriId).SingleOrDefault().KategoriAdi;
            _Urun.Acıklama = markaAdi.ToString() + kategoriAdi.ToString();
            Urun = _Urun;
            context.SaveChanges();
           return RedirectToAction("List");
        }
     
    }
}