using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Persistence;

namespace WeatherApp.Persistence.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly WeatherAppDbContext context;

        public UnitOfWorkEFCore(WeatherAppDbContext context)
        {
            this.context = context;
        }
        public async Task Persist()
        {
            await context.SaveChangesAsync();
        }

        public async Task Reverse()
        {
            await Task.CompletedTask;
        }
    }
}
