using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.UseCases.Weather.Queries.GetCurrentWeather;
using Weather.Application.Utilities.Mediator;
using WeatherApp.WeatherbitAPI.Entities;
using WeatherApp.WeatherbitAPI.Contracts;
using System.Text.Json;

namespace Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather
{
    public class UseCaseWeatherForecast :  IRequestHandler<QueryGetForecastWeather,
                                                            List<WeatherForecastDTO>>
    {
        public IApiClient ApiClient { get; }
        private string apiUrl { get; set; }
        private string key { get; set; }

        public UseCaseWeatherForecast(IApiClient apiClient, IConfiguration configuration)
        {
            ApiClient = apiClient;
            this.apiUrl = configuration["APIConfiguration:PathAPI"];
            this.key = configuration["APIConfiguration:key"];
        }

        public async Task<List<WeatherForecastDTO>> Handle(QueryGetForecastWeather request)
        {
            string baseUrl = this.apiUrl;
            string url = $"{baseUrl}?city={request.city}&key={this.key}";
            var RequestUrlCurrentWeather = new RequestUrlCurrentWeather(url);
            var stringJson = await this.ApiClient.GetWeatherAsync(RequestUrlCurrentWeather);
            return this.extractDataForDTOList(stringJson);
        }

        private List<WeatherForecastDTO> extractDataForDTOList(string stringJson)
        {
            int daysOfweek = 7;
            var data = JsonSerializer.Deserialize<Root>(stringJson.ToString());
            var weatherForecastDTOList = new List<WeatherForecastDTO>();

                for (int i=0; i< daysOfweek;  i++)
                {
                    var weatherForecastDTO = new WeatherForecastDTO
                    {
                        min_temp = data.data[i].min_temp,
                        max_temp = data.data[i].max_temp,
                        datetime = data.data[i].datetime,
                        description = data.data[i].weather.description
                    };
                weatherForecastDTOList.Add(weatherForecastDTO);
                }

            return weatherForecastDTOList;
        }
    }
}
