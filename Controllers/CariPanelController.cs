using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var deger = context.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            
            return View(deger);
        }
        //[HttpPost]
        //public ActionResult Index(Cariler c)
        //{
        //    var mail = (string)Session["CariMail"];
        //    var deger = context.Carilers.FirstOrDefault(x => x.CariMail == mail).ToString();

        //    ViewBag.m = mail;

        //    return View(deger);
        //}

    }
}