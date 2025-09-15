using NSubstitute;
using Weather.Application.Contracts.Persistence;
using Weather.Application.Contracts.Repositories;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Test;

[TestClass]
public class UseCaseSaveWeatherDatabaseTest
{
    private IRepositoryWeather repository;
    private IUnitOfWork unitOfWork;
    private UseCaseSaveWeatherDatabase useCase;
    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IRepositoryWeather>();
        unitOfWork = Substitute.For<IUnitOfWork>();

        useCase = new UseCaseSaveWeatherDatabase(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_createWeather() 
    {
        var command = new CreateWeatherCommand() {min_temp=22.0, max_temp=30.0, datetime=DateTime.Now, description = "this is a test" };
        var weatherSavedInDB = new WeatherApp.Domain.Entities.Weather() { min_temp = 22.0, max_temp = 30.0, datetime = DateTime.Now, description = "this is a test" };
        repository.save(Arg.Any<WeatherApp.Domain.Entities.Weather>()).Returns(weatherSavedInDB);
        var result = await useCase.Handle(command);

        await repository.Received(1).save(Arg.Any<WeatherApp.Domain.Entities.Weather>());
        await unitOfWork.Received(1).Persist();

        Assert.AreNotEqual(Guid.Empty, result);

    }
}
