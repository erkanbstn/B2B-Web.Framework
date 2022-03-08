using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        public ActionResult AnaDepartman()
        {
            var x = Baglanti.db.Departman.Where(c => c.Durum == true).ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDepartman(Departman s)
        {
            s.Durum = true;
            Baglanti.db.Departman.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaDepartman");
        }

        public ActionResult DepartmanSil(Departman p, int id)
        {
            var x = Baglanti.db.Departman.Find(id);
            x.Durum = false;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaDepartman");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var x2 = Baglanti.db.Departman.Find(id);
            return View("DepartmanGetir", x2);
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var x = Baglanti.db.Departman.Find(p.DepartmanID);
            x.DepartmanAd = p.DepartmanAd;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaDepartman");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var x = Baglanti.db.Personel.Where(c => c.PersonelID == id).ToList();
            var x2 = Baglanti.db.Departman.Where(c => c.DepartmanID == id).Select(d => d.DepartmanAd).FirstOrDefault();
            ViewBag.dgr3 = x2;
            return View(x);
        }
    }
}