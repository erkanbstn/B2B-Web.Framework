using MVCTicari.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult AnaGrafik()
        {
            return View();
        }
        public ActionResult Grafik2()
        {
            var gf = new Chart(600, 600);
            gf.AddTitle("Kategori ve Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 15, 20, 25 });
            return File(gf.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Grafik3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuc = Baglanti.db.Urun.ToList();
            sonuc.ToList().ForEach(n => xvalue.Add(n.UrunAd));
            sonuc.ToList().ForEach(n => yvalue.Add(n.Stok));
            var grafik = new Chart(width: 500, height: 500);
            grafik.AddTitle("Ürünler ve Stok Değerleri").AddSeries(chartType: "Pie", name: "Stok Verileri", xValue: xvalue, yValues: yvalue); ;
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }




        public ActionResult Grafik4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<ChartVeri> UrunListesi()
        {
            List<ChartVeri> veri = new List<ChartVeri>();
            veri.Add(new ChartVeri()
            {
                UrunAd = "Bilgisayar",
                Stok = 50
            }
                );
            veri.Add(new ChartVeri()
            {
                UrunAd = "Mobilya",
                Stok = 60
            }
                );
            veri.Add(new ChartVeri()
            {
                UrunAd = "Deodorant",
                Stok = 30
            }
                );
            return veri;
        }







        public ActionResult Grafik5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        //public List<ChartVeri> UrunListesi2()
        //{
        //    List<ChartVeri> veri = new List<ChartVeri>();
        //    veri = Baglanti.db.Urun.Select(b => new ChartVeri
        //    {
        //        UrunAd = b.UrunAd,
        //        Stok = b.Stok
        //    }).ToList();
        //    return veri;
        //}

        public List<ChartVeri> UrunListesi2()
        {

            List<ChartVeri> snf = new List<ChartVeri>();



            var sorgu = from x in Baglanti.db.Urun
                        group x by x.UrunAd into g
                        select new ChartVeri
                        {
                            UrunAd = g.Key,
                            Stok = g.Count()
                        };


            return (sorgu.ToList());

        }
    }
}