namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class WindDto
    {
        public double Speed { get; set; }
        public double Deg { get; set; }

        public WindDto(double speed, double deg)
        {
            Speed = speed;
            Deg = deg;
        }
    }
}