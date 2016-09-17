using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class OzellikController : Controller
    {
        // GET: Admin/Ozellik
        Entitie context = new Entitie();
       
        public ActionResult New(int id)
        {
            Ozellik ozellik = new Ozellik();
            ozellik.Id = context.UrunDetaylari.Where(x => x.Id == id).SingleOrDefault().Id;
            return View(ozellik);
        }
        [HttpPost]
        public ActionResult New(Ozellik Ozellik)
        {
            context.Ozellik.Add(Ozellik);
            context.SaveChanges();
            return RedirectToAction("Details","UrunDetay",new {id= Ozellik.Id });
        }
        
        public ActionResult Edit(int id)
        {
            return View(context.Ozellik.Where(x => x.ozellikId == id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Ozellik Ozellik)
        {
            Ozellik _ozellik = context.Ozellik.Where(x => x.ozellikId == Ozellik.ozellikId).SingleOrDefault();
            _ozellik.OzellikAdi = Ozellik.OzellikAdi;
            _ozellik.Özellik = Ozellik.Özellik;
            context.SaveChanges();
            return RedirectToAction("Details", "UrunDetay", new { id = _ozellik.Id });
        }
        public ActionResult Delete(int id)
        {
            Ozellik Ozellik = context.Ozellik.Where(x => x.ozellikId == id).SingleOrDefault();
            context.Ozellik.Remove(Ozellik);
            context.SaveChanges();
            return RedirectToAction("Details", "UrunDetay", new { id = Ozellik.Id });
        }
    }
}