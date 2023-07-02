using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WeatherDataIngestor
{
    public class WeatherDataProcessor
    {
        [FunctionName("ProcessWeatherData")]
        public void Run([QueueTrigger("add-weather-data", Connection = "connectionString")]string weatherData, ILogger log)
        {
            log.LogInformation($"Weather data : {weatherData}");
        }
    }
}
