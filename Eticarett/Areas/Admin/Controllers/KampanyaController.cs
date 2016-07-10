using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticarett.Areas.Admin.Models;
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

                Text = x.MarkaAdi,
                Value = x.Id.ToString()
               
            }
           
                );
            var kategori = context.Katagori.Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.Id.ToString()
            });
            ViewData["Id"] = kategori;
            ViewData["UrunId"] = marka;
            return View();
            
        }
        [HttpPost]
        public ActionResult New(Kampanya Kampanya)
        {
            Kampanya Kampanyadb = new Kampanya();
            context.Kampanya.Add(Kampanyadb);

            return View();
        }
    }
}