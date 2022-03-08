using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult AnaPersonel()
        {
            var x = Baglanti.db.Personel.ToList();
            return View(x);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {

            List<SelectListItem> deger = (from x in Baglanti.db.Departman select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanID.ToString() }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(Personel s)
        {
            if (Request.Files.Count > 0)
            {
                string dosya = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/AdminLTE-3.0.4/dist/img/" + dosya;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                s.PersonelGorsel = dosya;
            }

            Baglanti.db.Personel.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaPersonel");
        }

        public ActionResult PersonelDetay(int id)
        {
            var x = Baglanti.db.SatisHareket.Where(c => c.SatisID == id).ToList();
            var x2 = Baglanti.db.Personel.Where(c => c.PersonelID == id).Select(d => d.PersonelAd).FirstOrDefault();
            var x3 = Baglanti.db.Personel.Where(c => c.PersonelID == id).Select(d => d.PersonelSoyad).FirstOrDefault();
            ViewBag.dgr3 = x2 + " " + x3;
            return View(x);
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in Baglanti.db.Departman select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanID.ToString() }).ToList();
            ViewBag.dgr2 = deger;
            var x2 = Baglanti.db.Personel.Find(id);
            return View("PersonelGetir", x2);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var x = Baglanti.db.Personel.Find(p.PersonelID);

            if (Request.Files.Count > 0)
            {
                string dosya = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/AdminLTE-3.0.4/dist/img/" + dosya;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                x.PersonelGorsel = dosya;
            }
            x.PersonelSoyad = p.PersonelSoyad;
            x.PersonelAd = p.PersonelAd;
            x.Departman = p.Departman;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaPersonel");
        }
        public ActionResult PersonelResimDetay()
        {
            var x = Baglanti.db.Personel.ToList();
            return View(x);
        }
    }
}