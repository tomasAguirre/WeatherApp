using Polly;
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
        static HttpClient client =  new HttpClient();

        private readonly IAsyncPolicy<HttpResponseMessage> _weatherPolicy = Policy
    .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, //  3 attempts
        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // wait 2, 4, 8 seg, wait seconds between each attempt
    );

        public async Task<string> GetWeatherAsync(RequestUrlCurrentWeather query)
        {
            String weatherJson = string.Empty;
            HttpResponseMessage response = await _weatherPolicy.ExecuteAsync(() =>
            {
                return client.GetAsync(query.path);
            });

            if (response.IsSuccessStatusCode)
            {
                weatherJson = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception("was unable to create connection to the weather api");
            }
            return weatherJson;
        }
    }
}
