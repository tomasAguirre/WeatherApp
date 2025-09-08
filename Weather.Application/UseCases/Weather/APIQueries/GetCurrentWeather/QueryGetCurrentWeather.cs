using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Utilities.Mediator;

namespace Weather.Application.UseCases.Weather.Queries.GetCurrentWeather
{
    public class QueryGetCurrentWeather : IRequest<WeatherDetailDTO>
    {
        public QueryGetCurrentWeather()
        {
            
        }
        public QueryGetCurrentWeather(string city, string key)
        {
            this.city = city;
            this.key = key;
        }

        public string city {  get; set; }
        public string key { get; set; }
    }
}
