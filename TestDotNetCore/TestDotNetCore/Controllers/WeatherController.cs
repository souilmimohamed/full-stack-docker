using Core.Weather.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestDotNetCore.Models;

namespace TestDotNetCore.Controllers;

[Area("Weather")]
[Route("api/[controller]/[action]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    private const string MODULE = "Weather";

    [HttpGet]
    [SwaggerOperation(Tags = new[] { MODULE })]
    [ProducesResponseType(typeof(List<WeatherForecast>), 200)]
    public IActionResult GetWeatherForecast()
    {
        var response = _weatherService.GetWeather();
        return Ok(response);
    }
}