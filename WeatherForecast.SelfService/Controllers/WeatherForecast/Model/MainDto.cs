namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class MainDto
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }

        public MainDto(double temp, double feelsLike, double tempMin, double tempMax, long pressure, long humidity)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            TempMin = tempMin;
            TempMax = tempMax;
            Pressure = pressure;
            Humidity = humidity;
        }
    }
}