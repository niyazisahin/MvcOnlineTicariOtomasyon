using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        // GET: Urun
        public ActionResult Index(string p)
        {
            var urunler = from x in context.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrunEkle()
        {

            List<SelectListItem> deger = (from x in context.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoryId.ToString()
                                          }).ToList();

            ViewBag.deger1 = deger;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(Urun u)
        {
            if (ModelState.IsValid == true)
            {
                context.Uruns.Add(u);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("YeniUrunEkle"); 
            

        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            context.Uruns.Remove(deger);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult UrunGetir(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("UrunGetir");
            //}
            //List<SelectListItem> deger = (from x in context.Kategoris.ToList()
            //                              select new SelectListItem
            //                              {
            //                                  Text = x.KategoriAd,
            //                                  Value = x.KategoryId.ToString()
            //                              }).ToList();
            //ViewBag.deger1 = deger;
            var urundeger = context.Uruns.Find(id);

            return View("UrunGetir", urundeger);  
        }


        public ActionResult UrunGuncelle(Urun u)
        {
            if (ModelState.IsValid)
            {
                Urun urun = context.Uruns.Find(u.UrunID);

                urun.Stok = u.Stok;
                urun.UrunAd = u.UrunAd;
                urun.Marka = u.Marka;
                urun.AlisFiyati = u.AlisFiyati;
                urun.SatisFiyati = u.SatisFiyati;

                urun.UrunGorsel = u.UrunGorsel;
                urun.Durum = u.Durum;
                urun.KategoryId = u.KategoryId;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("UrunGetir");

            
        }

        public ActionResult UrunListesi()
        {
            var liste = context.Uruns.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            var urun= context.Uruns.Find(id);
            ViewBag.deger1 = urun.UrunID;

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

            ViewBag.BirimFiyat = urun.SatisFiyati;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {
            var urun = context.Uruns.Find(s.UrunID);
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(s);
            
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }


    }
}