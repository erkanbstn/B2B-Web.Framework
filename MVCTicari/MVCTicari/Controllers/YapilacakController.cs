using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        public ActionResult AnaYapilacak()
        {
            int id = Convert.ToInt32(Session["AdminID"]);
            var x = Baglanti.db.Yapilacak.Where(b => b.Personel == id).ToList();
            return View(x);
        }
    }
}