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
            var recomendation = _recomendationService.GetRecomendation(forecast);
            return Ok(recomendation);
        }
    }
}
