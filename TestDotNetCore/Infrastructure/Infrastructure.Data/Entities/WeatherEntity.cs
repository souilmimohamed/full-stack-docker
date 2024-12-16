using System.Data;

namespace Infrastructure.Data.Entities;

public class WeatherEntity
{
    public int Id { get; set; }
    public DateTime? date { get; set; }
    public string summary { get; set; }
    public int? temperatureC { get; set; }
    public int? temperatureF { get; set; }

    public WeatherEntity()
    {
        
    }

    public WeatherEntity(DataRow dataRow)
    {
        Id=Convert.ToInt32(dataRow["Id"]);
        date=dataRow["date"]==System.DBNull.Value?(DateTime?)null:Convert.ToDateTime(dataRow["date"]);
        summary=dataRow["summary"]==System.DBNull.Value ? null:Convert.ToString(dataRow["summary"]);
        temperatureC=dataRow["temperatureF"]==System.DBNull.Value?(int?)null:Convert.ToInt32(dataRow["temperatureC"]);
        temperatureF=dataRow["temperatureC"]==System.DBNull.Value?(int?)null:Convert.ToInt32(dataRow["temperatureF"]);
    }
}