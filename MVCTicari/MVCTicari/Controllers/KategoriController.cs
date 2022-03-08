using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace MVCTicari.Controllers
{
    [Authorize(Roles = "A")]
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult AnaKategori(int sayfa = 1)
        {
            var x = Baglanti.db.Kategori.Where(c => c.KategoriDurum == true).ToList().ToPagedList(sayfa, 4);
            return View(x);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Kategori s)
        {
            s.KategoriDurum = true;
            Baglanti.db.Kategori.Add(s);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }

        public ActionResult KategoriSil(Kategori p, int id)
        {
            var x = Baglanti.db.Kategori.Find(id);
            x.KategoriDurum = false;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }
        public ActionResult KategoriGetir(int id)
        {
            var x = Baglanti.db.Kategori.Find(id);
            return View("KategoriGetir", x);
        }
        public ActionResult KategoriGuncelle(Kategori pl)
        {
            var x = Baglanti.db.Kategori.Find(pl.KategoriID);
            x.KategoriAd = pl.KategoriAd;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }

        public ActionResult CascadingIslem()
        {
            Cascading cs = new Cascading();
            cs.Kategoriler = new SelectList(Baglanti.db.Kategori, "KategoriID", "KategoriAd");
            cs.Urunler = new SelectList(Baglanti.db.Urun, "UrunID", "UrunAd");
            return View(cs);
        }

        public JsonResult UrunGetir(int id)
        {
            var urunler = (from x in Baglanti.db.Urun
                           join y in Baglanti.db.Kategori on x.Kategori1.KategoriID equals y.KategoriID
                           where x.Kategori1.KategoriID == id
                           select new
                           {
                               Text = x.UrunAd,
                               Value = x.UrunID.ToString()
                           }).ToList();
            return Json(urunler, JsonRequestBehavior.AllowGet);
        }
    }
}