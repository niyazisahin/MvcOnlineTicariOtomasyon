using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var kullaniciAd = (string)Session["KullaniciAd"];
            var admin = context.Admins.FirstOrDefault(x => x.KullaniciAd == kullaniciAd);

            var adminId = context.Admins.Where(x => x.KullaniciAd == kullaniciAd).Select(y => y.AdminId).FirstOrDefault();

            var mesajlar = context.Mesajlars.Where(x => x.Gonderen == "ADMIN").ToList();

            dynamic model = new ExpandoObject();
            model.admin = admin;
            model.mesajlar = mesajlar;

            return View(model);
        }

        public PartialViewResult AdminListelePartial()
        {
            var admins = context.Admins.ToList();
            return PartialView(admins);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult AdminBilgiGuncellePartial()
        {
            var kullaniciAd = (string)Session["KullaniciAd"];
            var admin = context.Admins.Where(x => x.KullaniciAd == kullaniciAd).FirstOrDefault();
            return PartialView(admin);
        }

        public ActionResult AdminBilgiGuncelle2(Admin a)
        {
            var kullaniciAd = (string)Session["KullaniciAd"];
            var admin = context.Admins.Where(x => x.KullaniciAd == kullaniciAd).FirstOrDefault();
            admin.KullaniciAd = a.KullaniciAd;
            admin.Sifre = a.Sifre;
            context.SaveChanges();
            return RedirectToAction("LogOut", "Admin");

        }

        public PartialViewResult AdminDuyuruPartial()
        {
            var kullaniciAd = (string)Session["KullaniciAd"];
            var mesajlar = context.Mesajlars.Where(x => x.Gonderen == "ADMIN").ToList();
            return PartialView(mesajlar);
        }



    }
}