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
    public class UrunDetayController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/UrunDetay   

        public ActionResult List()
        {
            List<string> imagelist = new List<string>();

            var Image = context.UrunDetaylari.ToList();
            foreach (var i in Image)
            {
                imagelist.Add(new Infrastructure.ImageLoad(i.resim, i.Id, 40, 40).ImagePath.ToString());
            }
            ViewData["image"] = imagelist.ToList();
            IEnumerable<UrunDetaylari> UrunDetay = context.UrunDetaylari.ToList();
            return View(UrunDetay);
        }
        public ActionResult New()
        {
            var Urun = context.Urunler.Select(x => new SelectListItem
            {

                Text = x.Acıklama,
                Value = x.Id.ToString()

            });
            ViewData["urunId"] = Urun;
            return View();
        }
        [HttpPost]
        public ActionResult New(UrunDetaylari UrunDetay, HttpPostedFileBase fileUploader)
        {
            Infrastructure.ImageSave Image = new Infrastructure.ImageSave(fileUploader);
            UrunDetay.resim = Image.Image;
            context.UrunDetaylari.Add(UrunDetay);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Delete(int id)
        {
            UrunDetaylari UrunDetay = context.UrunDetaylari.Find(id);
            context.UrunDetaylari.Remove(UrunDetay);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Edit(int id)
        {
            UrunDetaylari Detay = context.UrunDetaylari.Find(id);
            ViewBag.image = new Infrastructure.ImageLoad(Detay.resim, Detay.Id, 40, 40).ImagePath.ToString();
            return View(context.UrunDetaylari.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(UrunDetaylari UrunDetay, HttpPostedFileBase fileUploader)
        {
            UrunDetaylari _urundetey = context.UrunDetaylari.Find(UrunDetay.Id);
            if (fileUploader != null)
            {
                Infrastructure.ImageSave Image = new Infrastructure.ImageSave(fileUploader);
                _urundetey.resim = Image.Image;
            }
            _urundetey.model_cins = UrunDetay.model_cins;
            _urundetey.renk = UrunDetay.renk;
            _urundetey.stokSayisi = UrunDetay.stokSayisi;

            context.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View(context.Ozellik.Where(x=>x.Id==id).ToList());
        }
    }
}