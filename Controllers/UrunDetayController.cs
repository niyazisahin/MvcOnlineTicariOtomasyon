using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();
        Class1 cs = new Class1();
        
        // GET: UrunDetay
        public ActionResult Index()
        {
            cs.deger1 = context.Uruns.Where(x=>x.UrunID == 1).ToList();
            cs.deger2 = context.Detays.Where(x => x.DetayId == 1).ToList();
            
            return View(cs);
        }
    }
}