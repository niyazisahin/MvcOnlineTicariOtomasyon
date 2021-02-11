using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (!ModelState.IsValid)
            {
                return View("YeniUrunEkle");
            }
            context.Uruns.Add(u);
            context.SaveChanges();
            return RedirectToAction("Index");

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
            List<SelectListItem> deger = (from x in context.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoryId.ToString()
                                          }).ToList();
            ViewBag.deger1 = deger;
            var urundeger = context.Uruns.Find(id);

            return View("UrunGetir", urundeger);  
        }


        public ActionResult UrunGuncelle(Urun u)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("UrunGetir");
            //}

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

        public ActionResult UrunListesi()
        {
            var liste = context.Uruns.ToList();
            return View(liste);
        }


    }
}