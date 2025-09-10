using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Contracts.Persistence;
using Weather.Application.Contracts.Repositories;
using Weather.Application.Utilities.Mediator;

namespace Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather
{
    public class UseCaseSaveWeatherDatabase : IRequestHandler<CreateWeatherCommand, Guid>
    {
        private readonly IRepositoryWeather repositoryWeather;
        public IUnitOfWork UnitOfWork;
        public UseCaseSaveWeatherDatabase(IRepositoryWeather repositoryWeather, IUnitOfWork unitOfWork)
        {
            this.repositoryWeather = repositoryWeather;
            UnitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateWeatherCommand request)
        {
            
            var weather = new WeatherApp.Domain.Entities.Weather(request.min_temp, request.max_temp, request.datetime, request.description);
            try
            {
                bool weatherAlreadyExist = await repositoryWeather.checkIfAlreadyExists(weather.datetime);
                if (!weatherAlreadyExist)
                {
                    await repositoryWeather.save(weather);
                    await this.UnitOfWork.Persist();
                    return weather.Id;
                }
            }
            catch (Exception ex) 
            {
                await this.UnitOfWork.Reverse();
                throw ex;
            }
            return Guid.Empty;
        }
    }
}
