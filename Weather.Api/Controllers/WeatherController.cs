using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
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
        private readonly IMemoryCache _cache;

        public WeatherController(IMediator mediator, IMemoryCache cache)
        {
            this.mediator = mediator;
            this._cache = cache;
        }

        [HttpGet("GetWeather")]
        public async Task<ActionResult<WeatherDetailDTO>> GetWeather() 
        {
            string cacheKey = "Weather";
            var query = new QueryGetCurrentWeather();
            query.city = "San Salvador";

            if (!_cache.TryGetValue(cacheKey, out WeatherDetailDTO result))
            {
                result = await this.mediator.Send(query);

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                // save the cache object
                _cache.Set(cacheKey, result, options);
            }
                var SqlQuery = new CreateWeatherCommand(result.min_temp, result.max_temp, DateTime.Parse(result.datetime), result.description);
                await this.mediator.Send(SqlQuery);
            return result;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult<List<WeatherForecastDTO>>> GetWeatherForecast() 
        {
            var query = new QueryGetForecastWeather();
            String cacheKey = "ListOfWeather";
            query.city = "San Salvador";
            if (!_cache.TryGetValue(cacheKey, out List<WeatherForecastDTO> result))
            {
                result = await this.mediator.Send(query);

                var options = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, result, options);
            }
            var SqlQuery = new CreateWeatherForecastCommand(result);
            await this.mediator.Send(SqlQuery);
            return result;
        }
    }
}
