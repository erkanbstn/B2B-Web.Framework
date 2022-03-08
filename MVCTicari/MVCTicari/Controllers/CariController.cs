using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class CariController : Controller
    {

        public ActionResult AnaCari()
        {
            var x = Baglanti.db.Cari.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cari c)
        {
            Baglanti.db.Cari.Add(c);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaCari");
        }
        public ActionResult CariSil(int id)
        {
            var x = Baglanti.db.Cari.Find(id);
            Baglanti.db.Cari.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaCari");
        }
        public ActionResult CariGetir(int id)
        {
            var x = Baglanti.db.Cari.Find(id);
            return View("CariGetir", x);
        }
        public ActionResult CariGuncelle(Cari p)
        {
            var x = Baglanti.db.Cari.Find(p.CariID);
            x.CariAd = p.CariAd;
            x.CariSoyad = p.CariSoyad;
            x.CariMail = p.CariMail;
            x.CariSehir = p.CariSehir;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaCari");
        }
        public ActionResult CariDetay(int id)
        {
            var x = Baglanti.db.SatisHareket.Where(c => c.SatisID == id).ToList();
            var x2 = Baglanti.db.Cari.Where(c => c.CariID == id).Select(v => v.CariAd).FirstOrDefault();
            var x3 = Baglanti.db.Cari.Where(c => c.CariID == id).Select(v => v.CariSoyad).FirstOrDefault();
            ViewBag.dgr5 = $"{x2} {x3}";
            return View(x);
        }
    }
}