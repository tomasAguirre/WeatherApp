using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Persistence;
using Weather.Application.Contracts.Repositories;
using WeatherApp.Persistence.Repositories;
using WeatherApp.Persistence.UnitsOfWork;

namespace WeatherApp.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServicesRegistry(this IServiceCollection services)
        {
            services.AddDbContext<WeatherAppDbContext>(options =>
                    options.UseSqlServer("name=WeatherAppConectionString"));

            services.AddScoped<IRepositoryWeather, RepositoryWeather>();
            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }
    }
}
