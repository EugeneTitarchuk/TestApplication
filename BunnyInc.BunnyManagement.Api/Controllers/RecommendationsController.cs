using BunnyInc.BunnyManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BunnyInc.BunnyManagement.Api.Controllers
{
    [ApiController]
    [Route("api/recommendations")]
    public class RecommendationsController : Controller
    {
        private readonly IRecomendationService _recomendationService;
        private readonly IWeatherForecastService _weatherForecastService;

        public RecommendationsController(
            IRecomendationService recomendationService, 
            IWeatherForecastService weatherForecastService
            )
        {
            _recomendationService = recomendationService;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var forecast = _weatherForecastService.GetWeatherForecasts();
            if (forecast is null)
            {
                throw new Exception("Cannot get weather forecast for today");
            }

            var recomendation = _recomendationService.GetRecomendation(forecast);
            return Ok(recomendation);
        }
    }
}
