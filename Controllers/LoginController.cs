using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Text;
using Limilabs.Mail.Fluent;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public static void MailGonder(string mesaj, string alici)
        {
            var kimden = new MailAddress("niyazisahin3800@gmail.com");
            var kime = new MailAddress(alici);
            const string konu = "Online TicariOtomasyon";
            using (var smtp = new SmtpClient 
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(kimden.Address, "Nsniyazi32@")
            })
            {
                using (var message = new MailMessage(kimden, kime) { Subject = konu, Body = mesaj })
                {
                    smtp.Send(message);
                }
            }
        }

        [HttpGet]
        public PartialViewResult KayitOlPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KayitOlPartial(Cariler c)
        {
            context.Carilers.Add(c);
            context.SaveChanges();
            var kontrol = context.Carilers.Find(c.CariId);
            if (kontrol != null)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + kontrol.CariAd + kontrol.CariSoyad);
                body.AppendLine("E-Mail Adresi: " + kontrol.CariMail);
                body.AppendLine("Konu: Deneme Mesajı");
                body.AppendLine("Mesaj: Sitemize Kayıt Olduüunuz İçin Teşekkürler. Bu Bir Deneme Mesajıdır. ");
                MailGonder(body.ToString(), kontrol.CariMail);
            }
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin(Cariler c)
        {
            var cariBilgi = context.Carilers.FirstOrDefault(x => x.CariMail == c.CariMail && x.CariSifre == c.CariSifre);
            if (cariBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(cariBilgi.CariMail, false); 
                Session["CariMail"] = cariBilgi.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");  
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        [HttpGet]
        public ActionResult PersonelLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelLogin(Admin admin)
        {
            var adminBilgi = context.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if(adminBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(adminBilgi.KullaniciAd, false);
                Session["KullaniciAd"] = adminBilgi.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}