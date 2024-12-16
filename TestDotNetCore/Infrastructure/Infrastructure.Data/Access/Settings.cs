namespace Infrastructure.Data.Access;

public class Settings
{
    public static void SetConnectionString(string connectionString)
    {
        _ConnectionString = connectionString;
    }
    public static string _ConnectionString { get; set; }

    public static string ConnectionString
    {
        get
        {
            return _ConnectionString;
        }
    }
}