using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult SayfaHata()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Hata400()
        {
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            return View("SayfaHata");
        }
        public ActionResult Hata403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("SayfaHata");
        }
        public ActionResult Hata404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("SayfaHata");
        }
    }
}