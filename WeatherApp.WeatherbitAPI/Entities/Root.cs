using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.WeatherbitAPI.Entities
{
    public class Root
    {
        public string city_name { get; set; }
        public string country_code { get; set; }
        public List<Datum> data { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string state_code { get; set; }
        public string timezone { get; set; }
    }
}
