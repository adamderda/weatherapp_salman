namespace WeatherForecast.SelfService.Controllers.WeatherForecast.Model
{
    public class WeatherDto
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Desciption { get; set; }
        public string Icon { get; set; }

        public WeatherDto(long id, string main, string desciption, string icon)
        {
            Id = id;
            Main = main;
            Desciption = desciption;
            Icon = icon;
        }
    }
}