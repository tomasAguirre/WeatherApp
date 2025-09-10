using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace Weather.Application.Contracts.Repositories
{
    public interface IRepositoryWeather : IRepository<WeatherApp.Domain.Entities.Weather>
    {

    }
}
