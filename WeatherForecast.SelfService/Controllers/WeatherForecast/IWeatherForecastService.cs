using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.SelfService.Controllers.WeatherForecast.Model;

namespace WeatherForecast.SelfService.Controllers.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecastDto>> GetWeatherForecastForCity(string cityName, string unitType);
        Task<WeatherForecastDto> GetWeatherForecastForUniqueCity(int cityId);
    }
}
