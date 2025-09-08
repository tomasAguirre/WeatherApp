using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.WeatherbitAPI.Entities
{
    public class Datum
    {
        public double app_max_temp { get; set; }
        public double app_min_temp { get; set; }
        public string datetime { get; set; }
        public double dewpt { get; set; }
        public double high_temp { get; set; }
        public double low_temp { get; set; }
        public object max_dhi { get; set; }
        public double max_temp { get; set; }
        public double min_temp { get; set; }
        public double moon_phase { get; set; }
        public double moon_phase_lunation { get; set; }

        public double precip { get; set; }
        public double temp { get; set; }

        public string valid_date { get; set; }
        public double vis { get; set; }
        public Weather weather { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public int wind_dir { get; set; }
        public double wind_gust_spd { get; set; }
        public double wind_spd { get; set; }
    }
}
