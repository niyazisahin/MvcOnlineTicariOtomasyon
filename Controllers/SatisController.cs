using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatisEkle()
        {
            List<SelectListItem> deger = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.deger1 = deger;

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariAd + " " +  x.CariSoyad,
                                              Value = x.CariId.ToString()
                                          }).ToList();
            ViewBag.deger2 = deger2;

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.deger3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatisEkle(SatisHareket s)
        {
            context.SatisHarekets.Add(s);
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisGuncelle(int id)
        {
            var s = context.SatisHarekets.Where(x => x.SatisId == id).Select(y => y.SatisId).FirstOrDefault();
            ViewBag.s = s;

            List<SelectListItem> deger = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.deger1 = deger;

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.deger3 = deger3;
            var satis = context.SatisHarekets.Find(id);
            return View(satis);
        }

        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var satis = context.SatisHarekets.Find(s.SatisId);
            satis.UrunID = s.UrunID;
            satis.CariId = s.CariId;
            satis.Adet = s.Adet;
            satis.BirimFiyat = s.BirimFiyat;
            satis.PersonelId = s.PersonelId;
            satis.Tutar = s.Tutar;

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisDetay(int id)
        {
            var satis = context.SatisHarekets.Where(x => x.SatisId == id).ToList();
            return View(satis);
        }
    }
}