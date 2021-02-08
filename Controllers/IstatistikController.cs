using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {

            try
            {
                var cari = context.Carilers.Count().ToString();
                ViewBag.d1 = cari;

                var urun = context.Uruns.Count().ToString();
                ViewBag.d2 = urun;

                var personel = context.Personels.Count().ToString();
                ViewBag.d3 = personel;

                var kategori = context.Kategoris.Count().ToString();
                ViewBag.d4 = kategori;

                var stok = context.Uruns.Sum(x => x.Stok).ToString();
                ViewBag.d5 = stok;

                var marka = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
                ViewBag.d6 = marka;

                var kritikSeviye = context.Uruns.Count(x => x.Stok < 20).ToString();
                ViewBag.d7 = kritikSeviye;

                var maxFiyatUrun = (from x in context.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
                ViewBag.d8 = maxFiyatUrun;

                var minFiyatUrun = (from x in context.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
                ViewBag.d9 = minFiyatUrun;

                var maxMarka = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
                ViewBag.d10 = maxMarka;

                var buzdolabi = context.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
                ViewBag.d11 = buzdolabi;

                var laptop = context.Uruns.Count(x => x.UrunAd.Contains("Laptop")).ToString();
                ViewBag.d12 = laptop;

                var enCokSatan = (from x in context.SatisHarekets orderby x.Adet descending select x.Urun.UrunAd).FirstOrDefault();
                ViewBag.d13 = enCokSatan;

                var kasa = context.SatisHarekets.Sum(x => x.Tutar).ToString();
                ViewBag.d14 = kasa;

                DateTime tarih = DateTime.Today;
                var bugunSatis = context.SatisHarekets.Count(x => x.Tarih == tarih).ToString();
                ViewBag.d15 = bugunSatis;

                var bugunKasa = context.SatisHarekets.Where(x => x.Tarih == tarih).Sum(x => x.Tutar).ToString();
                ViewBag.d16 = bugunKasa;
            }
            catch
            {
                ViewBag.d16 = 0;
            }
            return View();
        }

        public ActionResult Tablolar()
        {
            var sehirler = from x in context.Carilers
                           group x by x.CariSehir into a
                           select new GrupSinif
                           {
                               Sehir = a.Key,
                               Sayi = a.Count()
                               
                           };
            var toplamSehir = context.Carilers.Count().ToString();
            ViewBag.toplamsehir = toplamSehir;
            return View(sehirler.ToList());
        }

        public PartialViewResult Partial1()
        {
            var personeller = from x in context.Personels group x by x.Departman.DepartmanAd
                              into g select new GrupSinif2cs
                              {
                                  Departman = g.Key,
                                  Sayi = g.Count()
                              };
            return PartialView(personeller.ToList());
        }

        public PartialViewResult Partial2()
        {
            var cariler = context.Carilers.ToList();
            return PartialView(cariler);
        }

        public PartialViewResult Partial3()
        {
            var urunler = context.Uruns.ToList();
            return PartialView(urunler);
        }

        public PartialViewResult Partial4()
        {
            var markalar = from x in context.Uruns
                           group x by x.Marka
                           into g
                           select new GrupSinif3
                           {
                               Marka = g.Key.ToString(),
                               Sayi = g.Count()
                           };
            return PartialView(markalar.ToList());
        }
    }
}