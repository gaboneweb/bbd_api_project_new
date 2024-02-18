namespace UkukhulaAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
// "DBConnectionString": "Server=tcp:bbdbursary.database.windows.net,1433;Initial Catalog=Ukukhula;Persist Security Info=False;User ID=bbd-admin;Password=password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"
