using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticarett.Infrastructure;

namespace Eticarett.Areas.Admin.Controllers
{
    [SelectedTab("Homes")]
    public class HomesController : Controller
    {
        private Entitie context = new Entitie(); 
        // GET: Admin/Home
        
        public ActionResult List()
        {
           
            return View();
        }
    
       
    }
}