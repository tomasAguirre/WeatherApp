using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
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
            query.key = "ba6ada3fc90f4f8694cc0e3a4884a8c3";
            query.city = "San Salvador";
            string baseUrl = "https://api.weatherbit.io/v2.0/forecast/daily";
            string url = $"{baseUrl}?city={query.city}&key={query.key}";
            query.path = url;
            var result = await this.mediator.Send(query);
            return result;
        }
    }
}
