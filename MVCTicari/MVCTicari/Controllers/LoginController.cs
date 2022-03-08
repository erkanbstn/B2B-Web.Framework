using MVCTicari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MVCTicari.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Cari c)
        {
            Baglanti.db.Cari.Add(c);
            Baglanti.db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Cari c)
        {
            Baglanti.db.Cari.Add(c);
            Baglanti.db.SaveChanges();
            return RedirectToAction("GirisYap");

        }
        [HttpPost]
        public ActionResult PersonelGiris(Admin p)
        {
            var x = Baglanti.db.Admin.FirstOrDefault(b => b.Kullanici == p.Kullanici && b.Sifre == p.Sifre);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(x.Kullanici, false);
                Session["AdminID"] = x.AdminID;
                return RedirectToAction("AnaKategori", "Kategori");

            }
            else
            {
                return RedirectToAction("GirisYap");
            }
        }
        [HttpPost]
        public ActionResult CariGiris(Cari c)
        {
            var x = Baglanti.db.Cari.FirstOrDefault(b => b.CariMail == c.CariMail && b.CariSifre == c.CariSifre);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(x.CariMail, false);
                Session["CariID"] = x.CariID;
                Session["CariMail"] = x.CariMail;
                Session["Cari"] = x.CariAd + x.CariSoyad;
                return RedirectToAction("AnaCariPanel", "CariPanel");

            }
            else
            {
                return RedirectToAction("GirisYap");
            }

        }
    }
}