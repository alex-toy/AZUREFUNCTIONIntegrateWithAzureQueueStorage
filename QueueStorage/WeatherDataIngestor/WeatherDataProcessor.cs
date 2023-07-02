using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace WeatherDataIngestor
{
    public class WeatherDataProcessor
    {
        [FunctionName("ProcessWeatherData")]
        public void Run([QueueTrigger("add-weather-data", Connection = "connectionString")]string weatherData, ILogger log)
        {
            if (weatherData.Length > 20) throw new Exception("Too much data provided");
            log.LogInformation($"Weather data : {weatherData}");
        }
    }
}
