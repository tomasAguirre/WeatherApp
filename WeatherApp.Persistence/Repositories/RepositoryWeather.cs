using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Repositories;
using WeatherApp.Domain.Entities;
using WeatherApp.WeatherbitAPI.Entities;

namespace WeatherApp.Persistence.Repositories
{
    public class RepositoryWeather : Repository<WeatherApp.Domain.Entities.Weather>, IRepositoryWeather
    {
        private readonly WeatherAppDbContext dbContext;

        public RepositoryWeather(WeatherAppDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
