namespace Core.Weather.Models;

public class WeatherModel
{
    public int Id { get; set; }
    public DateTime? date { get; set; }
    public string summary { get; set; }
    public int? temperatureC { get; set; }
    public int? temperatureF { get; set; }

    public WeatherModel()
    {
        
    }

    public WeatherModel(Infrastructure.Data.Entities.WeatherEntity entity)
    {
        Id = entity.Id;
        date = entity.date;
        summary = entity.summary;
        temperatureC = entity.temperatureC;
        temperatureF = entity.temperatureF;
    }
}