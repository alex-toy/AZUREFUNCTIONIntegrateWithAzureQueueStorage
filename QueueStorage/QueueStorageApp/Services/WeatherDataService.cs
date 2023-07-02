using AzureHelper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QueueStorageApp.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QueueStorageApp.Services
{
    public class WeatherDataService : BackgroundService
    {
        private readonly ILogger<WeatherDataService> _logger;

        public WeatherDataService(ILogger<WeatherDataService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeiqueuestorage;AccountKey=1ODKcSiD/5rQPDtwRi0ADHNf0P27/PGUt0i7gY+CjO9Z7tr40fqBuPHUPQk1hhD6+YV6XUrq/WTQ+AStocDEdw==;EndpointSuffix=core.windows.net";
            string queueName = "add-weather-data";
            var queue = new AzureQueue(connectionString, queueName);

            while (!stoppingToken.IsCancellationRequested)
            {
                WeatherForecast weatherData = await queue.GetMessage<WeatherForecast>();
                ProcessData(weatherData);
            }
        }

        private async void ProcessData(WeatherForecast weatherForecast)
        {
            _logger.LogInformation($"Processing data : {weatherForecast}");
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}
