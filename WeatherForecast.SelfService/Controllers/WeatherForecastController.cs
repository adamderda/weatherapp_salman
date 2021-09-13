using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherForecast.SelfService.Controllers.WeatherForecast;

namespace WeatherForecast.SelfService.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        [Route("weatherforecast/city/{cityName}/{unitType}")]
        public ViewResult GetWeatherForecastView(string cityName, string unitType)
        {
            ViewBag.CityName = cityName;
            ViewBag.UnitType = unitType;

            return View("WeatherForecast");
        }

        [HttpGet]
        [Route("weatherforecast/uniquecity/{cityId}")]
        public ViewResult GetWeatherForecastForUniqueCityView(int cityId)
        {
            ViewBag.CityId = cityId;

            return View("WeatherForecastUnique");
        }

        [HttpPost]
        [Route("weatherforecast/city/{cityName}/{unitType}")]
        public async Task<ActionResult> HttpPost_GetWeatherForecastData(string cityName, string unitType)
        {
            var model = await _weatherForecastService.GetWeatherForecastForCity(cityName, unitType);
            return Ok(model);
        }

        [HttpPost]
        [Route("weatherforecast/uniquecity/{cityId}")]
        public async Task<ActionResult> HttpPost_GetWeatherForecastForUniqueCity(int cityId)
        {
            var model = await _weatherForecastService.GetWeatherForecastForUniqueCity(cityId);
            return Ok(model);
        }
    }
}
