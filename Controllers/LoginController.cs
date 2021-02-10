using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler c)
        {
            context.Carilers.Add(c);
            context.SaveChanges();
            return PartialView();
        }



        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Cariler c)
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