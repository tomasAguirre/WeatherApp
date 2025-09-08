using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Application.Utilities.Mediator;
using WeatherApp.WeatherbitAPI.Contracts;
using WeatherApp.WeatherbitAPI.Entities;
using Microsoft.Extensions.Configuration;
using Polly.Retry;
using Polly;

namespace Weather.Application.UseCases.Weather.Queries.GetCurrentWeather
{
    public class UseCaseGetWeather : IRequestHandler<QueryGetCurrentWeather, WeatherDetailDTO>
    {

        public IApiClient ApiClient { get; }
        private string apiUrl { get; set; }
        private string key { get; set; }

        public UseCaseGetWeather(IApiClient apiClient, IConfiguration configuration)
        {
            ApiClient = apiClient;
            this.apiUrl = configuration["APIConfiguration:PathAPI"];
            this.key = configuration["APIConfiguration:key"];
        }

        public async Task<WeatherDetailDTO> Handle(QueryGetCurrentWeather request)
        {
            string baseUrl = this.apiUrl;
            string url = $"{baseUrl}?city={request.city}&key={this.key}";
            var RequestUrlCurrentWeather = new RequestUrlCurrentWeather(url);
            var stringJson = await this.ApiClient.GetWeatherAsync(RequestUrlCurrentWeather);
            return this.extractDataForDTO(stringJson);
        }

        private WeatherDetailDTO extractDataForDTO(string stringJson) 
        {
            var data = JsonSerializer.Deserialize<Root>(stringJson.ToString());
            var weatherDetailDto = new WeatherDetailDTO
            {
                min_temp = data.data.First().min_temp,
                max_temp = data.data.First().max_temp,
                datetime = data.data.First().datetime,
                description = data.data.First().weather.description
            };

            return weatherDetailDto;
        }
    }
}
