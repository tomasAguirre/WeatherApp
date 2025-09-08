namespace Weather.Api.DTOs
{
    public class WeatherForecastDTO
    {
        public double minTemp { get; private set; }
        public double maxTemp { get; private set; }
        public DateTime date { get; private set; }
        public string description { get; private set; }
    }
}
