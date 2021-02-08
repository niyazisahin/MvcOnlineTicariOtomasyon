using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var faturalar = context.Faturas.ToList();
            return View(faturalar);
        }

        [HttpGet]
        public ActionResult YeniFaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniFaturaEkle(Fatura f)
        {
            context.Faturas.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FaturaGuncelle(int id)
        {
            var fatura = context.Faturas.Find(id);
            return View(fatura);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = context.Faturas.Find(f.FaturaId);
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Tarih = f.Tarih;
            fatura.Saat = f.Saat;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.VergiDairesi = f.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var detay = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            ViewBag.detay = detay;
            return View(detay);
        }

        [HttpGet]
        public ActionResult YeniKalemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalemEkle(FaturaKalem k)
        {
            context.FaturaKalems.Add(k);
            context.SaveChanges();
            return RedirectToAction("Index/FaturaDetay");
        }

    }
}