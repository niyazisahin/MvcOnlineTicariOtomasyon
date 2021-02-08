using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        Context context = new Context();
        // GET: Galeri
        public ActionResult Index()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }
    }
}