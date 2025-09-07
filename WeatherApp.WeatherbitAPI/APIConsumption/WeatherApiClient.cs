using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WeatherbitAPI.Contracts;
using WeatherApp.WeatherbitAPI.Entities;

namespace WeatherApp.WeatherbitAPI.APIConsumption
{
    public class WeatherApiClient : IApiClient
    {
        static HttpClient client = new HttpClient();
        public async Task<string> GetWeatherAsync(RequestUrlCurrentWeather query)
        {
            String weatherJson = string.Empty;
            HttpResponseMessage response = await client.GetAsync(query.path);
            if (response.IsSuccessStatusCode)
            {
                weatherJson = await response.Content.ReadAsStringAsync();
            }
            return weatherJson;
        }

        public Task<string> GetWeekWeatherAsync()
        {
            throw new NotImplementedException();
        }
    }
}
