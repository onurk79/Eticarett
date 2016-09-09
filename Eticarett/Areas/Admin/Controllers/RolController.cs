using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
    public class RolController : Controller
    {private Entitie context =new Entitie();
        // GET: Admin/Rol
        public ActionResult List()
        {
            return View(context.Roller.ToList());
        }
        public ActionResult Edit(int Id)
        {
            var Rol = context.Roller.Select(x => new SelectListItem
            {
                Text = x.RolAdi,
                Value = x.Id.ToString()
            });
            ViewData["RolId"] = Rol;

            return View(new Üye() {Eposta=context.Üye.Where(x=>x.Id==Id).SingleOrDefault().Eposta });
        }
        [HttpPost]
      public  ActionResult Edit( Üye uye)
        {
            Üye Uye = context.Üye.Find(uye.Id);
            Uye.RolId = uye.RolId;
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}