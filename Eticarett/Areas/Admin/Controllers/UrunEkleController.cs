using Eticarett.Infrastructure;
using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Eticarett.Areas.Admin.Models.picture;

namespace Eticaret.Areas.Admin.Controllers
{
    [SelectedTab("UrunEkle")]
    public class UrunEkleController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Admin/UrunEkle
        public ActionResult ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ekle(HttpPostedFileBase file_Uploader)
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
                marka.MarkaAcıklmasi = "das";
                marka.MarkaAdi = "saasd";
                context.Markalar.Add(marka);
                context.SaveChanges();
        
            }
            return View();
        }
    }
}