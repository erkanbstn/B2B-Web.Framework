using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        public ActionResult AnaFatura()
        {
            var x = Baglanti.db.Fatura.ToList();
            return View(x);
        }

        public ActionResult FaturaDetay(int id)
        {
            var x = Baglanti.db.Fatura.Where(c => c.FaturaID == id).ToList();
            var x2 = Baglanti.db.Fatura.Where(c => c.FaturaID == id).Select(v => v.FaturaSiraNo).FirstOrDefault();
            ViewBag.dgr = x2;
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFatura(Fatura s)
        {
            Baglanti.db.Fatura.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaFatura");
        }
        public ActionResult FaturaGetir(int id)
        {
            var x2 = Baglanti.db.Fatura.Find(id);
            return View("FaturaGetir", x2);
        }
        public ActionResult FaturaGuncelle(Fatura p)
        {
            var x = Baglanti.db.Fatura.Find(p.FaturaID);
            x.FaturaSeriNo = p.FaturaSeriNo;
            x.FaturaSiraNo = p.FaturaSiraNo;
            x.FaturaTarih = p.FaturaTarih;
            x.VergiDairesi = p.VergiDairesi;
            x.Saat = p.Saat;
            x.TeslimEden = p.TeslimEden;
            x.TeslimAlan = p.TeslimAlan;
            x.Toplam = p.Toplam;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaFatura");
        }
        public ActionResult FaturaninKalemi(int id)
        {
            var x = Baglanti.db.FaturaKalem.Where(c => c.Fatura == id).ToList();
            return View(x);
        }

        public ActionResult Dinamik()
        {
            Degerler d = new Degerler();
            d.FaturaDeger = Baglanti.db.Fatura.ToList();
            d.FaturaKalemDeger = Baglanti.db.FaturaKalem.ToList();
            return View(d);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] Kalemler)
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.FaturaTarih = Tarih;
            f.TeslimAlan = TeslimAlan;
            f.TeslimEden = TeslimEden;
            f.VergiDairesi = VergiDairesi;
            f.Toplam = decimal.Parse(Toplam);
            Baglanti.db.Fatura.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.Fatura = x.Fatura;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                Baglanti.db.FaturaKalem.Add(fk);
            }
            Baglanti.db.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }

    }
}