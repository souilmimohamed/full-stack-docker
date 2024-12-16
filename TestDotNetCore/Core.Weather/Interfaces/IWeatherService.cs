using Core.Weather.Models;

namespace Core.Weather.Interfaces;

public interface IWeatherService
{
    List<WeatherModel> GetWeather();
}