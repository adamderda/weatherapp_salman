using System.Collections.Generic;

namespace WeatherForecast.SelfService.WeatherForecastAPIClient.Model
{
    public class WeatherForecastResponse
    {
        public string Message { get; set; }
        public string Cod { get; set; }
        public int Count { get; set; }
        public List<WeatherForecastModel> List { get; set; }
    }

    public class WeatherForecastModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public int Dt { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public object Rain { get; set; }
        public object Snow { get; set; }
        public Clouds Clouds { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
