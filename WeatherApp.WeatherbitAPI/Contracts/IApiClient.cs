using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WeatherbitAPI.Entities;

namespace WeatherApp.WeatherbitAPI.Contracts
{
    public interface IApiClient
    {
        public Task<String> GetWeatherAsync(RequestUrlCurrentWeather query);
    }
}
