using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.WeatherbitAPI.Entities
{
    public class RequestUrlCurrentWeather
    {
        public RequestUrlCurrentWeather(string _path)
        {
            this.path = _path;
        }
        public string path { get; set; }


    }
}
