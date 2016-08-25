using Eticarett.Models;
using Eticarett.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eticarett.Controllers
{
    public class LoginController : Controller
    {
        private Entitie context = new Entitie();
        //GET: Login
        public ActionResult Login()
        {
            return View(new Uye());
        }
        [HttpPost]
        public ActionResult NewUser(ViewModels.Uye üye)
        {
            if (üye.Parola == üye.ParolaTekrar)
            {
                if (context.Üye.Where(x => x.Eposta == üye.Eposta).Count() == 0)
                {
                    Eticarett.Models.Üye _uye = new Üye();
                    _uye.Eposta = üye.Eposta;
                    _uye.Parola = üye.Parola;
                    _uye.RolId = 1;
                    context.Üye.Add(_uye);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Eposta", "E-posta  Kayıtlı!");
                    return RedirectToAction("Login", "Login", üye);
                }
            }
            else
            {
                ModelState.AddModelError("Parola", "Şifreler Uyuşmuyor!");
                return RedirectToAction("Login", "Login", üye);
            }
        }
        
          
           
       [HttpPost]
        public ActionResult Login(ViewModels.Uye üye,string returnUrl)
        {
            Üye üye1=  context.Üye.Where(x => x.Eposta == üye.Eposta && x.Parola == üye.Parola).SingleOrDefault();
            if(üye1==null)
            {
                ModelState.AddModelError("Parola", "E-posta yada şifre yanliş");
                return View(üye);
            }
            else {
                FormsAuthentication.SetAuthCookie(üye1.Eposta, true);
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
     
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}