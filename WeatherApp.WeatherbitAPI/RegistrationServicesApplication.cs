using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.WeatherbitAPI.APIConsumption;
using WeatherApp.WeatherbitAPI.Contracts;

namespace Weather.Application
{
    public static class RegistrationServicesApplication
    {
        public static IServiceCollection addApplicationServicesWeatherbitApi(this IServiceCollection service) 
        {
            service.AddScoped<IApiClient, WeatherApiClient>();

            return service;
        }
    }
}
