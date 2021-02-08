using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        Context context = new Context();
        // GET: Yapilacaklar
        public ActionResult Index()
        {
            var yapilacaklar = context.Yapilacaklars.ToList();



            var siparisSayisi = context.SatisHarekets.Count().ToString();
            ViewBag.siparis = siparisSayisi;

            var personelSayisi = context.Personels.Count().ToString();
            ViewBag.personel = personelSayisi;

            var musteriSayisi = context.Carilers.Count().ToString();
            ViewBag.musteri = musteriSayisi;

            var alis = context.Uruns.Sum(y => y.AlisFiyati);
            var satis = context.Uruns.Sum(x => x.SatisFiyati);
            var karOrani = (satis - alis) / alis * 100;
            ViewBag.kar = (int)karOrani;


            return View(yapilacaklar);
        }

        [HttpGet]
        public ActionResult YapilacakEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YapilacakEkle(Yapilacaklar y)
        {
            y.YapilacakDurum = false;
            context.Yapilacaklars.Add(y);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}