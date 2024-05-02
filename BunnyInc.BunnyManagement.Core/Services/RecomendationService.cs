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
            throw new NotImplementedException();
        }
    }
}
