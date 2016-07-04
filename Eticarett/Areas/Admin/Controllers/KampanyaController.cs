using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Areas.Admin.Controllers
{
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
              
                Value = x.MarkaAdi,
                Text=x.MarkaAdi
               
            }

                );
            ViewBag.UrunId = marka;
            ViewData["UrunId"] = marka;
            return View();
        }
        [HttpPost]
        public ActionResult New(Kampanya Kampanya)
        {
            return View();
        }
    }
}