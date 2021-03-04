using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departmanlar = context.Departmans.Where(x=>x.Durum == true).ToList();
            return View(departmanlar);
        }


        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult DepartmanEkle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanEkle");
            }
            context.Departmans.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            context.Departmans.Remove(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var deger = context.Departmans.Find(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanGuncelle");
            }
            var deger = context.Departmans.Find(d.DepartmanId);
            deger.DepartmanAd = d.DepartmanAd;
            deger.Durum = d.Durum;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personeller = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var detay = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dpt = detay;
            return View(personeller);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satislar = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var isim = context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " +  y.PersonelSoyad).FirstOrDefault();
            ViewBag.p = isim;
            return View(satislar);
        }


    }
}