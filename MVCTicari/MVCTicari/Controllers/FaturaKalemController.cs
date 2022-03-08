using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class FaturaKalemController : Controller
    {
        // GET: FaturaKalem
        public ActionResult AnaFaturaKalem()
        {
            var x = Baglanti.db.FaturaKalem.ToList();
            return View(x);
        }

        [HttpGet]
        public ActionResult YeniFaturaKalem()
        {
            List<SelectListItem> deger = (from c in Baglanti.db.Fatura select new SelectListItem { Text = c.FaturaSiraNo, Value = c.FaturaID.ToString() }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniFaturaKalem(FaturaKalem s)
        {
            Baglanti.db.FaturaKalem.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaFaturaKalem");
        }
        public ActionResult FaturaKalemGetir(int id)
        {
            List<SelectListItem> deger = (from c in Baglanti.db.Fatura select new SelectListItem { Text = c.FaturaSiraNo, Value = c.FaturaID.ToString() }).ToList();
            ViewBag.dgr2= deger;
            var x2 = Baglanti.db.FaturaKalem.Find(id);
            return View("FaturaKalemGetir", x2);
        }
        public ActionResult FaturaKalemGuncelle(FaturaKalem p)
        {
            var x = Baglanti.db.FaturaKalem.Find(p.FaturaKalemID);
            x.Aciklama = p.Aciklama;
            x.BirimFiyat = p.BirimFiyat;
            x.Miktar = p.Miktar;
            x.Tutar = p.Tutar;
            x.Fatura = p.Fatura;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaFaturaKalem");
        }
        public ActionResult FaturaKalemSil(int id)
        {
            var x = Baglanti.db.FaturaKalem.Find(id);
            Baglanti.db.FaturaKalem.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaFaturaKalem");

        }
    }
}