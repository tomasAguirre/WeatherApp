using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Repositories;

namespace WeatherApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WeatherAppDbContext context;

        public Repository(WeatherAppDbContext context)
        {
            this.context = context;
        }
         public async Task<bool> checkIfAlreadyExists(DateTime date)
        {
            bool exists = await context.Set<WeatherApp.Domain.Entities.Weather>()
                                            .AnyAsync(w => w.datetime == date);
            return exists;
        }

        public Task<T> save(T Entity)
        {
            this.context.Add(Entity);
            return Task.FromResult(Entity);
        }
    }
}
