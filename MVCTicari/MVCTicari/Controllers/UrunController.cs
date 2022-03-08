using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult AnaUrun()
        {
            var x = Baglanti.db.Urun.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from x in Baglanti.db.Kategori select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun s)
        {
            Baglanti.db.Urun.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaUrun");
        }

        public ActionResult UrunSil(Urun p)
        {
            var x = Baglanti.db.Urun.Find(p.UrunID);
            Baglanti.db.Urun.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaUrun");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger = (from x in Baglanti.db.Kategori select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr2 = deger;
            var x2 = Baglanti.db.Urun.Find(id);
            return View("UrunGetir", x2);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var x = Baglanti.db.Urun.Find(p.UrunID);
            x.UrunAd = p.UrunAd;
            x.Marka = p.Marka;
            x.SatisFiyat = p.SatisFiyat;
            x.AlisFiyat = p.AlisFiyat;
            x.Kategori = p.Kategori;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaUrun");
        }
        public ActionResult PdfCikti()
        {
            var x = Baglanti.db.Urun.ToList();
            return View(x);
        }
    }
}