using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult AnaIstatistik()
        {
            var deger1 = Baglanti.db.Cari.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = Baglanti.db.Urun.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = Baglanti.db.Personel.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = Baglanti.db.Kategori.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = Baglanti.db.Urun.Sum(c => c.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from c in Baglanti.db.Urun select c.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = Baglanti.db.Urun.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from c in Baglanti.db.Urun orderby c.SatisFiyat descending select c.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from c in Baglanti.db.Urun orderby c.SatisFiyat ascending select c.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = Baglanti.db.Urun.Count(c => c.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = Baglanti.db.Urun.Count(c => c.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = Baglanti.db.Urun.GroupBy(c => c.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = Baglanti.db.Urun.Where(b => b.UrunID == Baglanti.db.SatisHareket.GroupBy(c => c.Urun).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(n => n.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = Baglanti.db.SatisHareket.Sum(c => c.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = Baglanti.db.SatisHareket.Count(c => c.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = Baglanti.db.SatisHareket.Where(c => c.Tarih == bugun).Sum(v => (decimal?)v.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult KolayTablo()
        {
            var x = from c in Baglanti.db.Cari
                    group c by c.CariSehir into g
                    select new Degerler
                    {
                        Sehir = g.Key,
                        Sayi = g.Count()
                    };
            return View(x.ToList());
        }
        public PartialViewResult KolayT1()
        {
            var x = from v in Baglanti.db.Personel group v by v.Departman1.DepartmanAd into g select new Degerler { Departman = g.Key, Sayi2 = g.Count() };
            return PartialView(x.ToList());
        }
        public PartialViewResult KolayT2()
        {
            var x = Baglanti.db.Cari.ToList();
            return PartialView(x);
        }
        public PartialViewResult KolayT3()
        {
            var x = Baglanti.db.Urun.ToList();
            return PartialView(x);
        }
        public PartialViewResult KolayT4()
        {
            var x = from v in Baglanti.db.Urun group v by v.Marka into g select new Degerler { Marka = g.Key, Sayi3 = g.Count() };
            return PartialView(x.ToList());
        }
        public PartialViewResult KolayT5()
        {
            var x = Baglanti.db.Kategori.ToList();
            return PartialView(x);
        }
    }
}