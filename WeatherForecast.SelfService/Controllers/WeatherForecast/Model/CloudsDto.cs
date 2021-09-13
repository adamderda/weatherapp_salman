namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class CloudsDto
    {
        public long All { get; set; }

        public CloudsDto(long all)
        {
            All = all;
        }
    }
}