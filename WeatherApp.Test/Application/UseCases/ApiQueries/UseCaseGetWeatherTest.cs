using Castle.Core.Configuration;
using NSubstitute;
using System.Runtime.InteropServices;
using Weather.Application.UseCases.Weather.Queries.GetCurrentWeather;
using WeatherApp.Test.MockObjects;
using WeatherApp.WeatherbitAPI.Contracts;

namespace WeatherApp.Test;

[TestClass]
public class UseCaseGetWeatherTest
{
    public IApiClient ApiClient;
    UseCaseGetWeather useCase;

    [TestInitialize]
    public void Setup()
    {
        ApiClient = Substitute.For<IApiClient>();
        var settings = new Dictionary<string, string>
        {
            {"APIConfiguration:PathAPI", "https://api.weatherbit.io/v2.0/forecast/daily"},
            {"APIConfiguration:key", "ba6ada3fc90f4f8694cc0e3a4884a8c3"}
        };

        var mockConfig = new MockConfiguration(settings);

        useCase = new UseCaseGetWeather(ApiClient, mockConfig);
    }

    [TestMethod]
    public void QueryAPI_ReturnWeatherDetailDTO()
    {
        var query = new QueryGetCurrentWeather() { city = "San Salvador", key = "123" };
        var result = useCase.Handle(query);

        Assert.IsNotNull(result);
    }
}
