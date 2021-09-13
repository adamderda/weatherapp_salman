using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.SelfService.Controllers.WeatherForecast.Model;
using WeatherForecast.SelfService.WeatherForecastAPIClient;
using WeatherForecast.SelfService.WeatherForecastAPIClient.Model;

namespace WeatherForecast.SelfService.Controllers.WeatherForecast
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private readonly IWeatherForecastAPIClientService _weatherForecastAPIClientService;

        public WeatherForecastService(IWeatherForecastAPIClientService weatherForecastAPIClientService)
        {
            _weatherForecastAPIClientService = weatherForecastAPIClientService;
        }

        public async Task<List<WeatherForecastDto>> GetWeatherForecastForCity(string cityName, string unitType)
        {
            if (string.IsNullOrEmpty(cityName)) {
                throw new ArgumentNullException($"City '{cityName}' can not be null");
            }
            
            List<WeatherForecastModel> weatherForecast = await _weatherForecastAPIClientService.GetWeatherForecastForCity(cityName, unitType);
            List<WeatherForecastDto> weatherForecastDto = MappedToWeatherForecastListDto(weatherForecast);

            return weatherForecastDto;
        }

        private List<WeatherForecastDto> MappedToWeatherForecastListDto(List<WeatherForecastModel> weatherForecast)
        {
            List<Weather> weatherList = new List<Weather>();

            List<WeatherForecastDto> weatherForecastDto = weatherForecast
                .Select(c =>
                new WeatherForecastDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Coord = new CoordDto(c.Coord.Lat, c.Coord.Lon),
                    Clouds = new CloudsDto(c.Clouds.All),
                    Dt = c.Dt,
                    Main = new MainDto(c.Main.Temp, c.Main.FeelsLike, c.Main.TempMin, c.Main.TempMax, c.Main.Pressure, c.Main.Humidity),
                    Rain = c.Rain,
                    Snow = c.Snow,
                    Sys = new SysDto(c.Sys.Id, c.Sys.Type, c.Sys.Country, c.Sys.Sunrise, c.Sys.Sunset),
                    Weather = new List<WeatherDto>(weatherList.Select(w => new WeatherDto(w.Id, w.Main, w.Desciption, w.Icon))),
                    Wind = new WindDto(c.Wind.Speed, c.Wind.Deg),
                }).ToList();
            return weatherForecastDto;
        }

        public async Task<WeatherForecastDto> GetWeatherForecastForUniqueCity(int cityId)
        {
            if (cityId <= 0) {
                throw new ArgumentNullException($"City Id '{cityId}' is invalid");
            }

            WeatherForecastModel weatherForecast = await _weatherForecastAPIClientService.GetWeatherForecastForUniqueCity(cityId);
            WeatherForecastDto weatherForecastDto = MappedToWeatherForecastDto(weatherForecast);

            return weatherForecastDto;
        }

        private WeatherForecastDto MappedToWeatherForecastDto(WeatherForecastModel weatherForecast)
        {
            List<Weather> weatherList = new List<Weather>();
            WeatherForecastDto weatherForecastDto = new WeatherForecastDto();
            weatherForecastDto.Id = weatherForecast.Id;
            weatherForecastDto.Name = weatherForecast.Name;
            weatherForecastDto.Coord = new CoordDto(weatherForecast.Coord.Lat, weatherForecast.Coord.Lon);
            weatherForecastDto.Clouds = new CloudsDto(weatherForecast.Clouds.All);
            weatherForecastDto.Dt = weatherForecast.Dt;
            weatherForecastDto.Main = new MainDto(weatherForecast.Main.Temp, weatherForecast.Main.FeelsLike, weatherForecast.Main.TempMin, weatherForecast.Main.TempMax, weatherForecast.Main.Pressure, weatherForecast.Main.Humidity);
            weatherForecastDto.Rain = weatherForecast.Rain;
            weatherForecastDto.Snow = weatherForecast.Snow;
            weatherForecastDto.Sys = new SysDto(weatherForecast.Sys.Id, weatherForecast.Sys.Type, weatherForecast.Sys.Country, weatherForecast.Sys.Sunrise, weatherForecast.Sys.Sunset);
            weatherForecastDto.Weather = new List<WeatherDto>(weatherList.Select(w => new WeatherDto(w.Id, w.Main, w.Desciption, w.Icon)));
            weatherForecastDto.Wind = new WindDto(weatherForecast.Wind.Speed, weatherForecast.Wind.Deg);
            return weatherForecastDto;
        }
    }
}
