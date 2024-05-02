using BunnyInc.BunnyManagement.Core.Models;
using BunnyInc.BunnyManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BunnyInc.BunnyManagement.Api.Controllers
{
    [ApiController]
    [Route("api/forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public WeatherForecast? Get([FromQuery] string location)
        {
            if (location == null)
            {
                _logger.LogDebug("Location not set - use dafault");
                return _weatherForecastService.GetWeatherForecasts();
            }

            var forecast = _weatherForecastService.GetWeatherForecasts(location);

            return forecast;
        }

        [HttpGet("{days:int}")]
        public IEnumerable<WeatherForecast> GetPeriod(int days, [FromQuery] string? location)
        {
            return _weatherForecastService.GetWeatherForecasts(days, location);
        }
    }
}
