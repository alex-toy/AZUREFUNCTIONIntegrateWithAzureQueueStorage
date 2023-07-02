using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace WeatherDataIngestor
{
    public class WeatherDataProcessor
    {
        [FunctionName("ProcessWeatherData")]
        public void Run([QueueTrigger("add-weather-data", Connection = "connectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
