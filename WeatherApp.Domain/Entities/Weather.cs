using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
    public class Weather
    {
        public Weather()
        {
            
        }
        public Guid Id { get;  set; }
        public double min_temp {  get;  set; }
        public double max_temp { get;  set; }
        public DateTime datetime { get;  set; }
        public string description { get;  set; }

        public Weather(double min_temp, double max_temp, DateTime datetime, string description)
        {
            this.Id = Guid.NewGuid();
            this.min_temp = min_temp;
            this.max_temp = max_temp;
            this.datetime = datetime;
            this.description = description;
        }
    }
}
