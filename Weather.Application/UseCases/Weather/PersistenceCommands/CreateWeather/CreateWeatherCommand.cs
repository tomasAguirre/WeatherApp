using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Utilities.Mediator;

namespace Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather
{
    public class CreateWeatherCommand : IRequest<Guid>
    {
        public CreateWeatherCommand()
        {
            
        }
        public CreateWeatherCommand(double min_temp, double max_temp, DateTime datetime, string description)
        {
            this.min_temp = min_temp;
            this.max_temp = max_temp;
            this.datetime = datetime;
            this.description = description;
        }

        public double min_temp { get; set; }
        public double max_temp { get; set; }
        public DateTime datetime { get; set; }
        public string description { get; set; }
    }
}
