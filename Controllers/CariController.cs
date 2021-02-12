using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers 
{
    public class CariController : Controller
    {
        Context context = new Context();
        // GET: Cari 
        public ActionResult Index() 
        {
            var cariler = context.Carilers.ToList();
             
            return View(cariler);
        }
        
        [HttpGet]
        public ActionResult YeniCariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCariEkle(Cariler c)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniCariEkle");
            }
            context.Carilers.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Carilers.Find(id);
            context.Carilers.Remove(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var cari = context.Carilers.Find(id);
            return View(cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGuncelle");
            }
            var cari = context.Carilers.Find(c.CariId);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            cari.CariMail = c.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariDetay(int id)
        {
            var cariDetay = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = context.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cari;

            return View(cariDetay);
        }
    }
}