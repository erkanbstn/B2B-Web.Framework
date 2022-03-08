using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class KargoController : Controller
    {
        public ActionResult AnaKargo(string hece)
        {
            if (!string.IsNullOrEmpty(hece))
            {
                var v = from b in Baglanti.db.KargoDetay select b;
                v = v.Where(b => b.TakipKodu.Contains(hece) && b.Alici == "Erkan Bostan");
                return View(v.ToList());
            }
            var x = Baglanti.db.KargoDetay.Where(b => b.Alici == "Erkan Bostan").ToList();
            return View(x);
            //var x = Baglanti.db.KargoDetay.ToList();
            //return View(x);
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random r = new Random();
            string[] takipno = { "A", "B", "C", "D", "E" };
            int k1, k2, k3, s1, s2, s3;
            k1 = r.Next(0, takipno.Length);
            k2 = r.Next(0, takipno.Length);
            k3 = r.Next(0, takipno.Length);
            s1 = r.Next(100, 1000);
            s2 = r.Next(10, 99);
            s3 = r.Next(10, 99);
            string kod = s1.ToString() + takipno[k1] + s2.ToString() + takipno[k2] + s3.ToString() + takipno[k3];
            ViewBag.tkp = kod;
            return View();
        }
        [HttpPost]
        public ActionResult Yenikargo(KargoDetay k)
        {
            k.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            Baglanti.db.KargoDetay.Add(k);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKargo");
        }
        public ActionResult KargoDetay(string id)
        {
            var x = Baglanti.db.KargoTakip.Where(b => b.TakipKodu == id).ToList();
            return View(x);
        }
    }
}