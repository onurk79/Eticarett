using Eticarett.Infrastructure;
using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Eticarett.Areas.Admin.Models.picture;

namespace Eticarett.Areas.Admin.Controllers
{
    [SelectedTab("UrunEkle")]
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

            return View();
        }
        [HttpPost]
        public ActionResult New(HttpPostedFileBase file_Uploader)
        {
           
            if (file_Uploader != null)
            {
                string fileName = string.Empty;
                string destinationPath = string.Empty;
                fileName = Path.GetFileName(file_Uploader.FileName);
                byte[] img = null;
                BinaryReader br = new BinaryReader(file_Uploader.InputStream);
                img = br.ReadBytes((int)file_Uploader.InputStream.Length);
                Markalar marka = new Markalar();
                marka.MarkaLogo = img;
                marka.MarkaAcıklmasi = "Spor";
                marka.MarkaAdi = "Nike";
                context.Markalar.Add(marka);
                context.SaveChanges();
        
            }
            return View();
        }
    }
}