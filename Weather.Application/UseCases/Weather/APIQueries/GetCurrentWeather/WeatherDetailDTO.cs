using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Application.UseCases.Weather.Queries.GetCurrentWeather
{
    public class WeatherDetailDTO
    {
        public double min_temp { get;  set; }
        public double max_temp { get; set; }
        public string datetime { get; set; }
        public string description { get;  set; }
    }
}
