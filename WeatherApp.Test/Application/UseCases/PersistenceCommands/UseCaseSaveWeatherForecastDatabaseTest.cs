using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Weather.Application.Contracts.Persistence;
using Weather.Application.Contracts.Repositories;
using Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeatherForecast;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Test;

[TestClass]
public class UseCaseSaveWeatherForecastDatabaseTest
{
    private IRepositoryWeather repository;
    private IUnitOfWork unitOfWork;
    private UseCaseSaveWeatherForecastDatabase useCase;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IRepositoryWeather>();
        unitOfWork = Substitute.For<IUnitOfWork>();

        useCase = new UseCaseSaveWeatherForecastDatabase(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_createForecastWeather() 
    {
        List<WeatherForecastDTO> listWeather = new List<WeatherForecastDTO>()
        {
            new WeatherForecastDTO() { min_temp = 12.0, max_temp = 22.0, datetime = DateTime.Now.ToString(), description = "test" },
            new WeatherForecastDTO() { min_temp = 10.0, max_temp = 31.0, datetime = DateTime.Now.ToString(), description = "test2" }
        };

        CreateWeatherForecastCommand command = new CreateWeatherForecastCommand(listWeather);
        await useCase.Handle(command);

        repository.Received(2);
        await unitOfWork.Received(2).Persist();
    }

}
