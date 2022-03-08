using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTicari.Controllers
{
    public class QrIslemleriController : Controller
    {
        // GET: QrIslemleri
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string qrcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
    }
}