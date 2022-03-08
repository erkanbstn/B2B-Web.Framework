using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class SatisHareketController : Controller
    {
        // GET: SatisHareket
        public ActionResult AnaSatis()
        {
            var x = Baglanti.db.SatisHareket.ToList();
            return View(x);
        }
        public ActionResult SatisDetay(int id)
        {
            var x2 = Baglanti.db.SatisHareket.Where(c => c.Personel == id).ToList();
            return View(x2);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger = (from x in Baglanti.db.Personel select new SelectListItem { Text = x.PersonelAd + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in Baglanti.db.Cari select new SelectListItem { Text = x.CariAd + x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in Baglanti.db.Urun select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            Baglanti.db.SatisHareket.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSatis");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger = (from x in Baglanti.db.Personel select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in Baglanti.db.Cari select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in Baglanti.db.Urun select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var x2 = Baglanti.db.SatisHareket.Find(id);
            return View("SatisGetir", x2);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var x = Baglanti.db.SatisHareket.Find(p.SatisID);
            x.Personel = p.Personel;
            x.Cari = p.Cari;
            x.Urun = p.Urun;
            x.Adet = p.Adet;
            x.Fiyat = p.Fiyat;
            x.Tarih = p.Tarih;
            x.ToplamTutar = p.ToplamTutar;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSatis");
        }
    }
}