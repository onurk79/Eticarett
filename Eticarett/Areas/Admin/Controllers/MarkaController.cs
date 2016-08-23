﻿using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
    public class MarkaController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/Marka
        public ActionResult List()
        {
            var Marka = context.Markalar.ToList();
            List<Eticarett.ViewModels.Marka> markalıst =new List<Eticarett.ViewModels.Marka>();
            foreach( var marka in Marka )
            {
                Infrastructure.Image image = new Infrastructure.Image(marka.MarkaLogo,marka.Id,40,40);
              markalıst.Add(  new Eticarett.ViewModels.Marka()
              { Id=marka.Id,imagePath=image.ImagePath,MarkaAcıklmasi=marka.MarkaAcıklmasi,MarkaAdi=marka.MarkaAdi});
            }
            return View(markalıst);
        }
        public ActionResult Delete(int id)
        {
            Markalar Markalar = context.Markalar.Find(id);
            context.Markalar.Remove(Markalar);
            context.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult New()
        {
            return View();
        }
    }
}