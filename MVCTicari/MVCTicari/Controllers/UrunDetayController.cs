using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        public ActionResult AnaUrunDetay()
        {
            Degerler d = new Degerler();
            d.UrunDeger = Baglanti.db.Urun.Where(c => c.UrunID == 1).ToList(); 
            d.UrunDetayDeger = Baglanti.db.UrunDetay.Where(c => c.DetayID == 1).ToList(); 
            return View(d);
        }
    }
}