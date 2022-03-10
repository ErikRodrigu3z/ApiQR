using Microsoft.AspNetCore.Mvc;

namespace ApiQR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnv;

        public WeatherForecastController(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get(string code)
        {
            var qr = QRCodeWriter.CreateQrCodeWithLogo(code, _hostEnv.WebRootPath + "/img/visual-studio-logo.png", 300).ToHtmlTag();
            return ";";
        }
    }
}