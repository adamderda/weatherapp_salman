using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.SelfService.WeatherForecastAPIClient;
using Xunit;

namespace WeatherForecast.SelfService.Tests.WeatherForecast
{
    public class WeatherForecastAPIClientTest
    {
        [Fact]
        public async Task GetWeatherForecastForCity_InputCityWithMetric_ReturnsSameCityWithMetric()
        {
            //Arrange
            var handlerMock = new MockHttpMessageHandler(HttpStatusCode.OK,
                @"{ ""message"": ""accurate"", ""cod"": ""200"", ""count"": 5, ""list"": [ { ""id"": 2643743, ""name"": ""London"", ""coord"": { ""lat"": 51.5085, ""lon"": -0.1257 }, ""main"": { ""temp"": 15.89, ""feels_like"": 15.73, ""temp_min"": 12.99, ""temp_max"": 17.4, ""pressure"": 1020, ""humidity"": 84 }, ""dt"": 1631484555, ""wind"": { ""speed"": 0.45, ""deg"": 85 }, ""sys"": { ""country"": ""GB"" }, ""rain"": null, ""snow"": null, ""clouds"": { ""all"": 100 }, ""weather"": [ { ""id"": 804, ""main"": ""Clouds"", ""description"": ""overcast clouds"", ""icon"": ""04n"" } ] }, { ""id"": 6058560, ""name"": ""London"", ""coord"": { ""lat"": 42.9834, ""lon"": -81.233 }, ""main"": { ""temp"": 20.14, ""feels_like"": 20.46, ""temp_min"": 18.38, ""temp_max"": 20.83, ""pressure"": 1015, ""humidity"": 86 }, ""dt"": 1631484545, ""wind"": { ""speed"": 1.54, ""deg"": 320 }, ""sys"": { ""country"": ""CA"" }, ""rain"": null, ""snow"": null, ""clouds"": { ""all"": 90 }, ""weather"": [ { ""id"": 701, ""main"": ""Mist"", ""description"": ""mist"", ""icon"": ""50d"" } ] }, { ""id"": 4517009, ""name"": ""London"", ""coord"": { ""lat"": 39.8865, ""lon"": -83.4483 }, ""main"": { ""temp"": 28.24, ""feels_like"": 28.72, ""temp_min"": 26.75, ""temp_max"": 29.9, ""pressure"": 1017, ""humidity"": 50 }, ""dt"": 1631484577, ""wind"": { ""speed"": 4.47, ""deg"": 197 }, ""sys"": { ""country"": ""US"" }, ""rain"": null, ""snow"": null, ""clouds"": { ""all"": 1 }, ""weather"": [ { ""id"": 800, ""main"": ""Clear"", ""description"": ""clear sky"", ""icon"": ""01d"" } ] }, { ""id"": 4298960, ""name"": ""London"", ""coord"": { ""lat"": 37.129, ""lon"": -84.0833 }, ""main"": { ""temp"": 27.99, ""feels_like"": 28.81, ""temp_min"": 26.91, ""temp_max"": 28.36, ""pressure"": 1024, ""humidity"": 54 }, ""dt"": 1631484576, ""wind"": { ""speed"": 3.6, ""deg"": 220 }, ""sys"": { ""country"": ""US"" }, ""rain"": null, ""snow"": null, ""clouds"": { ""all"": 1 }, ""weather"": [ { ""id"": 800, ""main"": ""Clear"", ""description"": ""clear sky"", ""icon"": ""01d"" } ] }, { ""id"": 5367815, ""name"": ""London"", ""coord"": { ""lat"": 36.4761, ""lon"": -119.4432 }, ""main"": { ""temp"": 35.77, ""feels_like"": 34.94, ""temp_min"": 34.16, ""temp_max"": 38.3, ""pressure"": 1012, ""humidity"": 26 }, ""dt"": 1631484798, ""wind"": { ""speed"": 3.6, ""deg"": 260 }, ""sys"": { ""country"": ""US"" }, ""rain"": null, ""snow"": null, ""clouds"": { ""all"": 0 }, ""weather"": [ { ""id"": 800, ""main"": ""Clear"", ""description"": ""clear sky"", ""icon"": ""01d"" } ] } ] }");

            var httpClient = new HttpClient(handlerMock)
            {
                BaseAddress = new Uri("http://api.openweathermap.org/"),
            };

            var subjectUnderTest = new WeatherForecastAPIClientService(httpClient);

            //Act
            var result = await subjectUnderTest.GetWeatherForecastForCity("London", "metric");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
            Assert.True(handlerMock.NumberOfCalls == 1);
            Assert.True(handlerMock.Request.Method == HttpMethod.Get);
            Assert.True(handlerMock.Request.RequestUri == new Uri("http://api.openweathermap.org/data/2.5/find?q=London&units=metric&appid=1cb6ace31e50401f28b864f0b23fdc68"));
        }

        [Fact]
        public async Task GetWeatherForecastForUniqueCity_InputUniqueCityId_ReturnsSameCityId()
        {
            //Arrange
            var handlerMock = new MockHttpMessageHandler(HttpStatusCode.OK,
                @"{ ""coord"": { ""lon"": -81.233, ""lat"": 42.9834 }, ""weather"": [ { ""id"": 804, ""main"": ""Clouds"", ""description"": ""overcast clouds"", ""icon"": ""04d"" } ], ""base"": ""stations"", ""main"": { ""temp"": 297.09, ""feels_like"": 297.71, ""temp_min"": 292.11, ""temp_max"": 297.31, ""pressure"": 1013, ""humidity"": 83 }, ""visibility"": 10000, ""wind"": { ""speed"": 5.74, ""deg"": 264, ""gust"": 7.26 }, ""clouds"": { ""all"": 93 }, ""dt"": 1631469912, ""sys"": { ""type"": 2, ""id"": 2004764, ""country"": ""CA"", ""sunrise"": 1631444502, ""sunset"": 1631490049 }, ""timezone"": -14400, ""id"": 6058560, ""name"": ""London"", ""cod"": 200 }");

            var httpClient = new HttpClient(handlerMock)
            {
                BaseAddress = new Uri("http://api.openweathermap.org/"),
            };

            int cityId = 6058560;
            var subjectUnderTest = new WeatherForecastAPIClientService(httpClient);

            //Act
            var result = await subjectUnderTest.GetWeatherForecastForUniqueCity(cityId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(cityId, result.Id);
            Assert.True(handlerMock.NumberOfCalls == 1);
            Assert.True(handlerMock.Request.Method == HttpMethod.Get);
            Assert.True(handlerMock.Request.RequestUri == new Uri("http://api.openweathermap.org/data/2.5/weather?id=6058560&appid=1cb6ace31e50401f28b864f0b23fdc68"));
        }

        private class MockHttpMessageHandler : HttpMessageHandler
        {
            private readonly HttpStatusCode _statusCode;
            private readonly string _response;

            public int NumberOfCalls { get; private set; }
            public HttpRequestMessage Request { get; private set; }

            public MockHttpMessageHandler(HttpStatusCode statusCode, string response)
            {
                _statusCode = statusCode;
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                NumberOfCalls++;
                Request = request;
                return Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = _statusCode,
                    Content = new StringContent(_response)
                });
            }
        }
    }
}
