using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Application.Utilities.Mediator;
using WeatherApp.WeatherbitAPI.Contracts;
using WeatherApp.WeatherbitAPI.Entities;
using WeatherApp.Domain.Entities;

namespace Weather.Application.UseCases.Weather.Queries.GetCurrentWeather
{
    public class UseCaseGetWeather : IRequestHandler<QueryGetCurrentWeather, WeatherDetailDTO>
    {
        public IApiClient ApiClient { get; }
        public UseCaseGetWeather(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public async Task<WeatherDetailDTO> Handle(QueryGetCurrentWeather request)
        {
            //string baseUrl = "https://api.weatherbit.io/v2.0/current";
            string baseUrl = "https://api.weatherbit.io/v2.0/forecast/daily";
            string url = $"{baseUrl}?city={request.city}&key={request.key}";
            var RequestUrlCurrentWeather = new RequestUrlCurrentWeather(url);
            var stringJson = await this.ApiClient.GetWeatherAsync(RequestUrlCurrentWeather);
            var data = JsonSerializer.Deserialize<Root>(stringJson.ToString());
            var weatherDetailDto = new WeatherDetailDTO { min_temp = data.data.First().min_temp, max_temp = data.data.First().max_temp, 
                                                         datetime = data.data.First().datetime, description = data.data.First().weather.description };
            return weatherDetailDto;
        }
    }
}
