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
    private const string MODULE = "Weather";

    [HttpGet]
    [SwaggerOperation(Tags = new[] { MODULE })]
    [ProducesResponseType(typeof(WeatherForecast[]), 200)]
    public IActionResult GetWeatherForecast()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return Ok(forecast.ToArray());
    }
}