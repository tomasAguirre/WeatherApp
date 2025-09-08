using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Utilities.Mediator;

namespace Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather
{
    public class QueryGetForecastWeather: IRequest<List<WeatherForecastDTO>>
    {
        public string city { get; set; }
        public string key { get; set; }
    }
}
