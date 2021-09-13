using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.SelfService.WeatherForecastAPIClient.Model;

namespace WeatherForecast.SelfService.WeatherForecastAPIClient
{
    public interface IWeatherForecastAPIClientService
    {
        Task<List<WeatherForecastModel>> GetWeatherForecastForCity(string cityName, string unitType);
        Task<WeatherForecastModel> GetWeatherForecastForUniqueCity(int cityId);
    }
}
