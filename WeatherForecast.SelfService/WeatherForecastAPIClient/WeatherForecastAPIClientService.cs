using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherForecast.SelfService.WeatherForecastAPIClient.Model;

namespace WeatherForecast.SelfService.WeatherForecastAPIClient
{
    public class WeatherForecastAPIClientService : IWeatherForecastAPIClientService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private const string URL = "http://api.openweathermap.org/";
        private readonly string _apiKey = "1cb6ace31e50401f28b864f0b23fdc68";

        public WeatherForecastAPIClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            _httpClient.BaseAddress = new Uri(URL);
            _httpClient.DefaultRequestHeaders.Add("appid", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<WeatherForecastModel>> GetWeatherForecastForCity(string cityName, string unitType)
        {
            var response = await _httpClient.GetAsync($"data/2.5/find?q={cityName}&units={unitType}&appid={_apiKey}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var weatherResponse = JsonSerializer.Deserialize<WeatherForecastResponse>(responseBody, _jsonSerializerOptions);
            var responseResult = weatherResponse.List;

            return responseResult;
        }

        public async Task<WeatherForecastModel> GetWeatherForecastForUniqueCity(int cityId)
        {
            var response = await _httpClient.GetAsync($"data/2.5/weather?id={cityId}&appid={_apiKey}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            WeatherForecastModel weatherModel = JsonSerializer.Deserialize<WeatherForecastModel>(responseBody, _jsonSerializerOptions);
            return weatherModel;
        }
    }
}
