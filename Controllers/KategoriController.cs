using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            context.Kategoris.Add(k);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var deger = context.Kategoris.Find(id);
            context.Kategoris.Remove(deger);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var deger = context.Kategoris.Find(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGuncelle");
            }
            var deger1 = context.Kategoris.Find(kategori.KategoryId);
            deger1.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}