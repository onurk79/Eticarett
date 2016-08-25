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
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            UrunDetaylari UrunDetay = context.UrunDetaylari.Find(id);
            context.UrunDetaylari.Remove(UrunDetay);
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}