using Eticarett.Models;
using Eticarett.ViewModels;
using System.Linq;
using System.Net.Mail;
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
        public ActionResult Login(ViewModels.Uye üye, string returnUrl)
        {
            if (üye.ParolaTekrar == null)
            {
                Üye üye1 = context.Üye.Where(x => x.Eposta == üye.Eposta && x.Parola == üye.Parola).SingleOrDefault();
                if (üye1 == null)
                {
                    ModelState.AddModelError("Parola", "E-posta yada şifre yanliş");
                    return View(üye);
                }
                else
                {
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
            else
            {

                if (üye.Parola == üye.ParolaTekrar)
                {
                    if (context.Üye.Where(x => x.Eposta == üye.Eposta).Count() == 0)
                    {

                        Eticarett.Models.Üye _uye = new Üye();
                        _uye.Eposta = üye.Eposta;
                        _uye.Parola = üye.Parola;
                        Roller rol = context.Roller.Where(x => x.Id == 1).SingleOrDefault();
                        _uye.RolId = rol.Id;
                        context.Üye.Add(_uye);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");


                    }
                    else
                    {
                        ModelState.AddModelError("ParolaTekrar", "E-posta  Kayıtlı!");
                        return RedirectToAction("Login", "Login", üye);
                    }
                }
                else
                {
                    ModelState.AddModelError("ParolaTekrar", "Şifreler Uyuşmuyor!");
                    return RedirectToAction("Login", "Login", üye);
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult iForgotMyPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult iForgotMyPassword(Uye Uye)
        {
            if (ModelState.IsValid)
            {
                var count = context.Üye.Where(s => s.Eposta.Equals(Uye.Eposta)).FirstOrDefault();
                if (count != null)
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                    var mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.From = new MailAddress("E_ticarett@hotmail.com");
                    mail.To.Add(Uye.Eposta);
                    mail.Subject = "Kullanıcı Bilgileri Hatırlatma";
                    string htmlBody;
                    htmlBody = "Şifreniz:" + count.Parola.ToString() + "<br>Giriş İçin <a href='#'>Tıklayınız</a>";
                    mail.Body = htmlBody;
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("E_ticarett@hotmail.com", "12345678,k");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    ModelState.AddModelError("Eposta", "Şifreniz Email Adresinize gönderilmiştir.");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Eposta", "Sitemizde Bu Email Adresi Kayıtlı Değil, Lütfen geçerli bir Email adresi giriniz");
                    return View();
                }
            }
            return View();
        }
    }
}