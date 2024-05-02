using BunnyInc.BunnyManagement.Core.Models;

namespace BunnyInc.BunnyManagement.Core.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts(int days, string? location);
        WeatherForecast? GetWeatherForecasts(); 
        WeatherForecast? GetWeatherForecasts(string location);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private const string _currentLocation = "Ukraine";

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Storm", "Rain"
        ];

        public IEnumerable<WeatherForecast> GetWeatherForecasts(int days, string? location)
        {
            return GetWeatherForecastsInternal(days, location);
        }

        public WeatherForecast? GetWeatherForecasts()
        {
            return GetWeatherForecastsInternal(days: 1, _currentLocation).FirstOrDefault();
        }

        public WeatherForecast? GetWeatherForecasts(string location)
        {
            return GetWeatherForecastsInternal(days: 1, location).FirstOrDefault();
        }

        private IEnumerable<WeatherForecast> GetWeatherForecastsInternal(int days, string? location)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
