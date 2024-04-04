using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiQR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QrController : ControllerBase
    {
        // https://github.com/codebude/QRCoder

        private readonly IWebHostEnvironment _hostEnv;
        private readonly QrGeneratorService _qr;

        public QrController(IWebHostEnvironment hostEnv, QrGeneratorService qr)
        {
            _hostEnv = hostEnv;
            _qr = qr;
        }
       
        [HttpGet]
        [Route("/QrCoder", Name = "QrCoder")]
        public string QrCoder(string code = "https://kybalionsoft.com/")
        {
            return _qr.GeneradeQR(code, _hostEnv.WebRootPath);
        }

    }
}