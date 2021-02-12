using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var personeller = context.Personels.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult YeniPersonelEkle()
        {
            List<SelectListItem> deger = (from x in context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Departman.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.deger1 = deger;
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniPersonelEkle(Personel p)
        {
            if(Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string dosyaUzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + dosyaUzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdi + dosyaUzanti;
            }
            context.Personels.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = context.Personels.Find(id);
            context.Personels.Remove(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            List<SelectListItem> deger = (from x in context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Departman.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.deger2 = deger;
            var personel = context.Personels.Find(id);
            return View(personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string dosyaUzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + dosyaUzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdi + dosyaUzanti;
            }
            var personel = context.Personels.Find(p.PersonelId);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelGorsel = p.PersonelGorsel;
            personel.DepartmanId = p.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe() {

            var personeller = context.Personels.ToList();

            return View(personeller);
        }


    }
}