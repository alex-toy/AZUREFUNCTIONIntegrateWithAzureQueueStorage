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
        private readonly IAzureQueue _queue;

        public WeatherDataService(ILogger<WeatherDataService> logger, IAzureQueue queue)
        {
            _logger = logger;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(20));
                WeatherForecast weatherData = await _queue.GetMessage<WeatherForecast>();
                ProcessData(weatherData);
            }
        }

        private async void ProcessData(WeatherForecast weatherForecast)
        {
            _logger.LogInformation($"Processing data : {weatherForecast}");
        }
    }
}
