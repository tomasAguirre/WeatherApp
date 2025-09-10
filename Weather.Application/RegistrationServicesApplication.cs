using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeatherForecast;
using Weather.Application.UseCases.Weather.Queries.GetCurrentWeather;
using Weather.Application.Utilities.Mediator;
using WeatherApp.WeatherbitAPI.APIConsumption;
using WeatherApp.WeatherbitAPI.Contracts;
using WeatherApp.WeatherbitAPI.Entities;

namespace Weather.Application
{
    public static class RegistrationServicesApplication
    {
        public static IServiceCollection addApplicationServicesApplication(this IServiceCollection service) 
        {
            service.AddTransient<IMediator, SimpleMediator>();

            service.AddScoped<IRequestHandler<QueryGetCurrentWeather, WeatherDetailDTO>,
                                        UseCaseGetWeather>();

            service.AddScoped<IRequestHandler<QueryGetForecastWeather, List<WeatherForecastDTO>>,
                UseCaseWeatherForecast>();


            service.AddScoped<IRequestHandler<CreateWeatherCommand, Guid>, UseCaseSaveWeatherDatabase>();

            service.AddScoped<IRequestHandler<CreateWeatherForecastCommand>, UseCaseSaveWeatherForecastDatabase>();

            return service;
        }
    }
}
