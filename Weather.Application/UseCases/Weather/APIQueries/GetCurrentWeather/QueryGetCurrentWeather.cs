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
        public QueryGetCurrentWeather(string path, string city, string key)
        {
            this.path = path;
            this.city = city;
            this.key = key;
        }

        public string path { get; set; }
        public string city {  get; set; }
        public string key { get; set; }
    }
}
