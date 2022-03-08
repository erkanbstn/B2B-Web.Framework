using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCTicari.Controllers
{
    public class CariPanelController : Controller
    {
        [HttpGet]
        public ActionResult AnaCariPanel()
        {
            int id = Convert.ToInt32(Session["CariID"]);
            var x = Baglanti.db.Cari.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult AnaCariPanel(Cari c)
        {
            int id = Convert.ToInt32(Session["CariID"]);
            var x = Baglanti.db.Cari.Find(id);
            x.CariAd = c.CariAd;
            x.CariSoyad = c.CariSoyad;
            x.CariSifre = c.CariSifre;
            x.CariSehir = c.CariSehir;
            Baglanti.db.SaveChanges();
            return View();
        }
        public PartialViewResult ProfilPartial()
        {
            int id = Convert.ToInt32(Session["CariID"]);
            var x = Baglanti.db.Cari.Where(b => b.CariID == id).ToList();
            return PartialView(x);
        }
        public PartialViewResult ProfilPartial2()
        {
            return PartialView();
        }
        public ActionResult CariSiparis()
        {
            int id = Convert.ToInt32(Session["CariID"]);
            var x = Baglanti.db.SatisHareket.Where(b => b.Cari == id).ToList();
            return View(x);
        }
        public ActionResult CariKargo(string hece)
        {
            string ad = Session["Cari"].ToString();
            if (!string.IsNullOrEmpty(hece))
            {
                var v = from b in Baglanti.db.KargoDetay select b;
                v = v.Where(b => b.TakipKodu.Contains(hece) && b.Alici == ad);
                return View(v.ToList());
            }
            var x = Baglanti.db.KargoDetay.Where(b => b.Alici == ad).ToList();
            return View(x);
        }
        public ActionResult CariCikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult CariMesajSideBar()
        {
            return PartialView();
        }
        public ActionResult CariMesaj()
        {
            string gonderen = Session["CariMail"].ToString();
            var x = Baglanti.db.Mesaj.Where(b => b.Alici == gonderen).ToList();
            return View(x);
        }
        [HttpPost]
        public ActionResult CariMesaj(string hece)
        {
            string gonderen = Session["CariMail"].ToString();
            if (!string.IsNullOrEmpty(hece))
            {
                var v = from b in Baglanti.db.Mesaj select b;
                v = v.Where(b => b.Gonderici.Contains(hece) && b.Alici == gonderen);
                return View(v.ToList());
            }
            var x = Baglanti.db.Mesaj.Where(b => b.Alici == gonderen).ToList();
            return View(x);
        }

        [HttpGet]
        public ActionResult CariGonderilenMesaj()
        {
            string gonderen = Session["CariMail"].ToString();

            var x = Baglanti.db.Mesaj.Where(b => b.Gonderici == gonderen).ToList();
            return View(x);

        }
        [HttpPost]
        public ActionResult CariGonderilenMesaj(string hece)
        {
            string gonderen = Session["CariMail"].ToString();

            if (!string.IsNullOrEmpty(hece))
            {
                var v = from b in Baglanti.db.Mesaj select b;
                v = v.Where(b => b.Alici.Contains(hece) && b.Gonderici == gonderen);
                return View(v.ToList());
            }
            var x = Baglanti.db.Mesaj.Where(b => b.Gonderici == gonderen).ToList();
            return View(x);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            string gonderen = Session["CariMail"].ToString();
            m.Gonderici = gonderen;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            Baglanti.db.Mesaj.Add(m);
            Baglanti.db.SaveChanges();
            return RedirectToAction("CariMesaj");
        }

        public ActionResult CariMesajDetay(int id)
        {
            var x = Baglanti.db.Mesaj.Where(b => b.MesajID == id).ToList();
            return View(x);
        }

        public ActionResult CariKargoDetay(string id)
        {
            var x = Baglanti.db.KargoTakip.Where(b => b.TakipKodu == id).ToList();
            return View(x);
        }
    }
}