using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();
        // GET: Kargo
        public ActionResult Index(string p) { 
             var kargolar = from x in context.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.KargoTakipKodu.Contains(p));
            }
        
            return View(kargolar.ToList());
        }

        public string KodUret()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E" };
            int s1 = random.Next(100, 1000);
            int s2 = random.Next(100, 1000);
            int s3 = random.Next(10, 99);
            string kod = s1.ToString() + karakterler[random.Next(0, 5)] + s2.ToString() + karakterler[random.Next(0, 5)] + s3.ToString();
            return kod;
        }
        [HttpGet]
        public ActionResult YeniKargoEkle()
        {

            ViewBag.takipKod = KodUret();


            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariAd.ToString() + " " + x.CariSoyad.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelAd.ToString() + " " + x.PersonelSoyad.ToString()
                                           }).ToList();
            ViewBag.deger3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargoEkle(KargoDetay k)
        {
            if (ModelState.IsValid == true)
            {
                    k.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    context.KargoDetays.Add(k);
                    context.SaveChanges();
                    return RedirectToAction("Index");
            }
            ViewBag.takipKod = KodUret();
            return View("YeniKargoEkle");
            
        }

        public ActionResult KargoDetay(string id)
        {
            var kargo = context.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(kargo);
        }
    }
}