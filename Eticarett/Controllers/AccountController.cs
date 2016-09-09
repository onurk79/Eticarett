using Eticarett.Models;
using System.Linq;
using System.Web.Mvc;

namespace Eticarett.Controllers
{
    public class AccountController : Controller
    {
        private Entitie context = new Entitie();
        // GET: Account
        [Authorize]
        public ActionResult Account(Üye uye)
        {
            Üye _uye = context.Üye.Where(x => x.Eposta == User.Identity.Name).SingleOrDefault();
            
            if(uye.Adres!=null)
                _uye.Adres = uye.Adres;
            if(uye.Eposta!=null)
                _uye.Eposta = uye.Eposta;
            if (uye.GuvenlikSorusu != null||uye.GuvenlikCevabı!=null)
            {
                _uye.GuvenlikCevabı = uye.GuvenlikCevabı;
                _uye.GuvenlikSorusu = uye.GuvenlikSorusu;
            }
            if (uye.Isim != null)
                _uye.Isim = uye.Isim;
            if (uye.Parola != null)
                _uye.Parola = _uye.Parola;
            if (uye.Soyisim != null)
                _uye.Soyisim = uye.Soyisim;
            if (uye.Tel != null)
                _uye.Tel = uye.Tel;

            context.SaveChanges();
            
            return View(_uye);
        }
        //[Authorize]
        //[HttpPost]
        //public ActionResult Account(Üye a)
        //{
        //    return View();
        //}
    }
}