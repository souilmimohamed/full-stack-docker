using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Access;

public class WeatherAccess
{
   private static IConfiguration _configuration;

   public WeatherAccess(IConfiguration configuration)
   {
      _configuration = configuration;
   }
   public static List<Infrastructure.Data.Entities.WeatherEntity> Get()
   {
      var dataTable = new DataTable();
      using (var sqlConnection = new SqlConnection(Settings.ConnectionString))
      {
         sqlConnection.Open();
         string query = "SELECT * FROM [Weather]";
         var sqlCommand = new SqlCommand(query, sqlConnection);
         
         new SqlDataAdapter(sqlCommand).Fill(dataTable);
      }

      if (dataTable.Rows.Count > 0)
         return dataTable.Rows.Cast<DataRow>().Select(x => new Infrastructure.Data.Entities.WeatherEntity(x)).ToList();
      else
         return null;
   }
}