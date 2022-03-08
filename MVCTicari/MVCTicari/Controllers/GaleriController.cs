using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        public ActionResult AnaGaleri()
        {
            var x = Baglanti.db.Urun.ToList();
            return View(x);
        }
    }
}