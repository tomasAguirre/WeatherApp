using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Persistence
{
    public class WeatherAppDbContext : DbContext
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherApp.Domain.Entities.Weather> weathers { get; set; }
    }
}
