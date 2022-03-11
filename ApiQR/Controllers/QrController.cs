using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace ApiQR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QrController : BaseController
    {
        // https://github.com/codebude/QRCoder
        public QrController(IWebHostEnvironment hostEnv) :base(hostEnv)
        {

        }
       
        [HttpGet]
        [Route("/QrCoder", Name = "QrCoder")]
        public string QrCoder(string code = "https://kybalionsoft.com/")
        {
            return GeneradeQR(code);
        }

    }
}