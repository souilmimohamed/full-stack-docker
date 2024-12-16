using Core.Weather.Interfaces;
using Core.Weather.Models;

namespace Core.Weather.Handlers;

public partial class WeatherService:IWeatherService
{
    public List<WeatherModel> GetWeather()
    {
        var entities = Infrastructure.Data.Access.WeatherAccess.Get();
        return entities?.Select(x=>new WeatherModel(x)).ToList();
    }
}