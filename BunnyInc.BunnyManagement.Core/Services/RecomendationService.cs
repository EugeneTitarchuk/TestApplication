using BunnyInc.BunnyManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyInc.BunnyManagement.Core.Services
{
    public interface IRecomendationService
    {
        Recomendation GetRecomendation(WeatherForecast forecast);
    }
    public class RecomendationService : IRecomendationService
    {
        public Recomendation GetRecomendation(WeatherForecast forecast)
        {

            if (forecast is { TemperatureC: < 10 })
            {
                return new Recomendation(RecomendationType.SitHome, "Too cold");
            }

            if (forecast.Summary == "Storm")
            {
                return new Recomendation(RecomendationType.GoToShelter, "Be safe");
            }

            if (forecast.Summary == "Rain")
            {
                return new Recomendation(RecomendationType.TakeUmbrella, "Water folling from the sky");
            }

            if (forecast.Summary == "Hot")
            {
                return new Recomendation(RecomendationType.TakeSunglasses, "Sunny");
            }

            return new Recomendation(RecomendationType.Default, "Nothing special");
        }
    }
}
