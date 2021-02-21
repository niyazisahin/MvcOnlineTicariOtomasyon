using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();

        // GET: CariPanel

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = context.Carilers.FirstOrDefault(x => x.CariMail == mail);
            var ad = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd).FirstOrDefault();
            var soyad = context.Carilers.Where(x => x.CariMail == mail).Select(x => x.CariSoyad).FirstOrDefault();
            var sehir = context.Carilers.Where(x => x.CariMail == mail).Select(x => x.CariSehir).FirstOrDefault();
            var sifre = context.Carilers.Where(x => x.CariMail == mail).Select(x => x.CariSifre).FirstOrDefault();
            ViewBag.m = mail;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.sehir = sehir;
            ViewBag.sifre = sifre;

            return View(deger);
            
        }

        public ActionResult Index2(Cariler c)
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var cari = context.Carilers.Find(cariId);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            context.SaveChanges();
            return RedirectToAction("Index");

            
        }

        public ActionResult SiparisGoster()
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            //var cari = context.Carilers.Find(cariId);
            var satislar = context.SatisHarekets.Where(x => x.CariId == cariId).ToList();
            return View(satislar);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x=>x.Alici == mail).ToList();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;
            
            return View(degerler);
        }

        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);
            
        }

        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.MesajId == id).ToList().FirstOrDefault();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            var mail = (string)Session["CariMail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderen = mail; 
            context.Mesajlars.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }







    }
}