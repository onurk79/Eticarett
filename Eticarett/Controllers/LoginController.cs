using Eticarett.Models;
using Eticarett.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Controllers
{
    public class LoginController : Controller
    {
        private Entitie context = new Entitie();
        //GET: Login
        [HttpPost]
        public ActionResult Index(Uye üye)
        {
            return View();
        }
        
        public ActionResult Index()
        {
            return View(new Uye());
        }
       
        public ActionResult login(Üye üye)
        {
            Üye üye1=  context.Üye.Where(x => x.Eposta == üye.Eposta && x.Parola == üye.Parola).SingleOrDefault();
            return View();
        }
        public ActionResult Save(Üye üye)
        {
           
            context.Üye.Add(üye);
            context.SaveChanges();
            return View();
        }
    }
}