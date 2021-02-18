using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
       
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafik = new Chart(width: 500, height: 700);
            grafik.AddTitle("Kategori-Ürün Stok Sayısı");
            grafik.AddLegend("Stok");
            grafik.AddSeries("Degerler", xValue: new[] { "Mobilya", "Televizyon", "Elektronik", "Beyaz Eşya", },
                                        yValues: new[] { 500, 600, 700, 800 });
            grafik.Write();

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            Context context = new Context();
            var urunler = context.Uruns.ToList();
            urunler.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            urunler.ToList().ForEach(y => yvalue.Add(y.Stok));

            var grafik = new Chart(width: 500, height: 600);
            grafik.AddTitle("Ürün Stok Grafiği");
            grafik.AddLegend("Stok");
            grafik.AddSeries("Stok Sayısı", xValue: xvalue, yValues: yvalue);
            grafik.Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");


        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizationResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Class2> UrunListesi()
        {
            List<Class2> stokSinif = new List<Class2>();

            stokSinif.Add(new Class2()
            {
                UrunAd = "Bilgisayar",
                UrunStok = 100
            });

            stokSinif.Add(new Class2()
            {
                UrunAd = "Beyaz Eşya",
                UrunStok = 200
            });

            stokSinif.Add(new Class2()
            {
                UrunAd = "Mobilya",
                UrunStok = 150
            });

            stokSinif.Add(new Class2()
            {
                UrunAd = "Elektronik",
                UrunStok = 145
            });

            stokSinif.Add(new Class2()
            {
                UrunAd = "Televizyon",
                UrunStok = 345
            });

            return stokSinif;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizationResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Class3> UrunListesi2()
        {
            List<Class3> sinif3 = new List<Class3>();
            using (Context context = new Context())
            {
                sinif3 = context.Uruns.Select(x => new Class3
                {
                    UrunAD = x.UrunAd,
                    UrunSTOK = x.Stok
                }).ToList();
            }
            return sinif3;

        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}