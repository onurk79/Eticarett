﻿using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UrunFiyatController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/UrunFiyat
        public ActionResult List()
        {
            IEnumerable<UrunFiyat> UrunFiyat = context.UrunFiyat.ToList();
            return View(UrunFiyat);
        }
        public ActionResult New()
        {
            var Urun = context.UrunDetaylari.Select(x => new SelectListItem
            {

                Text = x.model_cins,
                Value = x.Id.ToString()

            });
            ViewData["UrunId"] = Urun;
            return View();
        }
        [HttpPost]
        public ActionResult New(UrunFiyat UrunFiyat)
        {
            context.UrunFiyat.Add(UrunFiyat);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            UrunFiyat UrunFiyat = context.UrunFiyat.Find(id);
            context.UrunFiyat.Remove(UrunFiyat);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Edit(int id)
        {
            return View(context.UrunFiyat.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(UrunFiyat fiyat)
        {
            UrunFiyat _fiyat = context.UrunFiyat.Find(fiyat.Id);
            _fiyat.KarOranı = fiyat.KarOranı;
            _fiyat.KdvOrani = fiyat.KdvOrani;
            _fiyat.AlisFiyati = fiyat.AlisFiyati;
            context.SaveChanges();
            return RedirectToAction("list");
        }
    }

}