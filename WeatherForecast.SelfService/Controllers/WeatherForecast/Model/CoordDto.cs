namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class CoordDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CoordDto(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}