using QRCoder;
using System.Drawing;

namespace Services
{
    public class QrGeneratorService
    { 

        public QrGeneratorService()
        {
                
        }

        public string GeneradeQR(string code, string webRootPath)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(webRootPath + "/img/visual-studio-logo.png"), 20);
            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return $"<img src=\"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}\" alt=\"Red dot\" />";
        }


    }
}
