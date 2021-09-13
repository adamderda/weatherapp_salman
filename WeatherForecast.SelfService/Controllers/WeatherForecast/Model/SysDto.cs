namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class SysDto
    {
        public long Id { get; set; }
        public long Type { get; set; }

        public string Country { get; set; }

        public long Sunrise { get; set; }

        public long Sunset { get; set; }

        public SysDto(long id, long type, string country, long sunrise, long sunset)
        {
            Id = id;
            Type = type;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}