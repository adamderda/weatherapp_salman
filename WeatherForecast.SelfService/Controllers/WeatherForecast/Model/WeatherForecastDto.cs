using System.Collections.Generic;

namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class WeatherForecastListDto
    {
        public string Message { get; set; }
        public string Cod { get; set; }
        public int Count { get; set; }
        public List<WeatherForecastDto> WeatherForecast { get; set; }

        public WeatherForecastListDto(List<WeatherForecastDto> weatherForecast)
        {
            WeatherForecast = weatherForecast;
        }
    }

    public class WeatherForecastDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CoordDto Coord { get; set; }
        public MainDto Main { get; set; }
        public int Dt { get; set; }
        public WindDto Wind { get; set; }
        public SysDto Sys { get; set; }
        public object Rain { get; set; }
        public object Snow { get; set; }
        public CloudsDto Clouds { get; set; }
        public List<WeatherDto> Weather { get; set; }
    }
}
