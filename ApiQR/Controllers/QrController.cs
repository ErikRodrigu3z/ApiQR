using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace ApiQR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QrController : ControllerBase
    {
        // https://github.com/codebude/QRCoder

        private readonly IWebHostEnvironment _hostEnv;

        public QrController(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }
       
        [HttpGet]
        [Route("/QrCoder", Name = "QrCoder")]
        public string QrCoder(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(_hostEnv.WebRootPath + "/img/visual-studio-logo.png"),20);
            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            string qr = $"<img src=\"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}\" alt=\"Red dot\" />";

            return qr;
        }

    }
}