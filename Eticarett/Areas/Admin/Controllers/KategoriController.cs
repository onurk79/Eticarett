﻿using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Eticarett.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private Entitie context =new Entitie();
        // GET: Admin/Kategori
        public ActionResult List()
        {
            return View(context.Katagori.ToList());
        }
        public ActionResult Delete(int id)
        {
            Katagori Kategori = context.Katagori.Find(id);
            context.Katagori.Remove(Kategori);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Katagori Kategori)
        {
            if(context.Katagori.Where(x=>x.KategoriAdi==Kategori.KategoriAdi).Count()==0)
            {
                context.Katagori.Add(Kategori);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}