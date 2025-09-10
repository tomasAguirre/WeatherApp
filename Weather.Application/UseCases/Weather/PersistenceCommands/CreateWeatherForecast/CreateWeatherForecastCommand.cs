using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather;
using Weather.Application.Utilities.Mediator;
using WeatherApp.Domain.Entities;

namespace Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeatherForecast
{
    public class CreateWeatherForecastCommand : IRequest
    {
        
        public List<WeatherForecastDTO> listWeather;

        public CreateWeatherForecastCommand(List<WeatherForecastDTO> listWeather)
        {
            this.listWeather = listWeather;
        }
    }
}
