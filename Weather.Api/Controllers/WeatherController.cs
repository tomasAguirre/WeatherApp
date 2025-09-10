using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Weather.Application.UseCases.Weather.APIQueries.GetForecastWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeather;
using Weather.Application.UseCases.Weather.PersistenceCommands.CreateWeatherForecast;
using Weather.Application.UseCases.Weather.Queries.GetCurrentWeather;
using Weather.Application.Utilities.Mediator;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator mediator;

        public WeatherController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherDetailDTO>> Get() 
        {
            var query = new QueryGetCurrentWeather();
            query.city = "San Salvador";
            var result = await this.mediator.Send(query);
            var SqlQuery = new CreateWeatherCommand(result.min_temp,result.max_temp, DateTime.Parse(result.datetime),result.description);
            await this.mediator.Send(SqlQuery);
            return result;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult<List<WeatherForecastDTO>>> GetWeatherForecast() 
        {
            var query = new QueryGetForecastWeather();
            query.city = "San Salvador";
            var result = await this.mediator.Send(query);
            var SqlQuery = new CreateWeatherForecastCommand(result);
            await this.mediator.Send(SqlQuery);
            return result;
        }
    }
}
