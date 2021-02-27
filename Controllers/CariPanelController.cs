using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();

        // GET: CariPanel

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Carilers.FirstOrDefault(x => x.CariMail == mail);

            var cariId = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var carix = context.SatisHarekets.Find(cariId);

            var toplamAlis = 0;
            decimal toplamTutar = 0;
            var toplamUrunSayisi = 0;

            if (carix != null)
            {
                         toplamAlis = context.SatisHarekets.Count(x => x.CariId == cariId);
                         toplamTutar = context.SatisHarekets.Where(x => x.CariId == cariId).Sum(y => y.Tutar);
                         toplamUrunSayisi = context.SatisHarekets.Where(x => x.CariId == cariId).Sum(y => y.Adet);
                
                        
            }
            else
            {
                 toplamAlis = 0;
                 toplamTutar = 0;
                 toplamUrunSayisi = 0;
            }

                 ViewBag.toplamUrunSayisi = toplamUrunSayisi;
                 ViewBag.toplamSatisTutari = toplamTutar;
                 ViewBag.toplamAlis = toplamAlis;



            var mesajlar = context.Mesajlars.Where(x => x.Alici == mail.ToString()).ToList();

            dynamic model = new ExpandoObject();
            model.degerler = degerler;
            model.mesajlar = mesajlar;

            return View(model);

        }

        public ActionResult Index2(Cariler c)
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var cari = context.Carilers.Find(cariId);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            context.SaveChanges();
            return RedirectToAction("Index");


        }

        [Authorize]
        public ActionResult SiparisGoster()
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            //var cari = context.Carilers.Find(cariId);
            var satislar = context.SatisHarekets.Where(x => x.CariId == cariId).ToList();

            return View(satislar);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.Alici == mail).ToList();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);
        }

        [Authorize]
        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);

        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.MesajId == id).ToList().FirstOrDefault();
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.mesajSayisi = mesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderen == mail).Count();
            ViewBag.gonderilenMesajSayisi = gonderilenMesajSayisi;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            var mail = (string)Session["CariMail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderen = mail;
            context.Mesajlars.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }

        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            dynamic model = new ExpandoObject();
            model.kargoDetays = context.KargoDetays;
            model.kargoTakips = context.KargoTakips;

            var mail = (string)Session["CariMail"];
            var kargolar = from x in context.KargoDetays select x;

            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.KargoTakipKodu.Contains(p));
            }
            var cariAd = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            var kargoTakipKodu = kargolar.Select(x => x.KargoTakipKodu).FirstOrDefault();
            model.kargoDetays = kargolar.Where(x => x.AliciCari == cariAd).ToList();
            model.kargoTakips = context.KargoTakips.Where(x => x.KargoTakipKodu == kargoTakipKodu).ToList();
            ViewBag.p = p;

            return View(model);

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult BilgiGuncelle()
        {
            var mail = (string)Session["CariMail"];
            var cariler = context.Carilers.Where(x => x.CariMail == mail).FirstOrDefault();
            return PartialView("BilgiGuncelle", cariler);
        }

        public PartialViewResult DuyuruPartial()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Gonderen == "ADMIN").ToList();

            return PartialView(mesajlar);
        }

        public ActionResult BilgiGuncelle2(Cariler cari)
        {
            var mail = (string)Session["CariMail"];
            var cari1 = context.Carilers.Where(x => x.CariMail == mail).FirstOrDefault();
            cari1.CariAd = cari.CariAd;
            cari1.CariSoyad = cari.CariSoyad;
            cari1.CariSehir = cari.CariSehir;
            cari1.CariMail = cari.CariMail;
            cari1.CariSifre = cari.CariSifre;
            context.SaveChanges();
            

            return RedirectToAction("Index");
        }


    }
    }
