using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Persistence;
using Weather.Application.Contracts.Repositories;
using Weather.Application.Utilities.Mediator;

namespace Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeatherForecast
{
    internal class UseCaseSaveWeatherForecastDatabase : IRequestHandler<CreateWeatherForecastCommand>
    {
        private readonly IRepositoryWeather repositoryWeather;
        public IUnitOfWork UnitOfWork;
        public UseCaseSaveWeatherForecastDatabase(IRepositoryWeather repositoryWeather, IUnitOfWork unitOfWork)
        {
            this.repositoryWeather = repositoryWeather;
            UnitOfWork = unitOfWork;
        }

        public async Task Handle(CreateWeatherForecastCommand request)
        {
            foreach (var w in request.listWeather) 
            {
                var weather = new WeatherApp.Domain.Entities.Weather(w.min_temp, w.max_temp, DateTime.Parse(w.datetime), w.description);
                try
                {
                        await repositoryWeather.save(weather);

                }
                catch (Exception ex)
                {
                    await this.UnitOfWork.Reverse();
                    throw ex;
                }
                await this.UnitOfWork.Persist();
            }
        }
    }
}
