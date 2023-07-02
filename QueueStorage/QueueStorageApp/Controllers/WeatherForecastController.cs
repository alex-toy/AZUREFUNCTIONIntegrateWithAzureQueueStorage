using AzureHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QueueStorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace QueueStorageApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("AddWeatherForecast")]
        public async Task AddWeatherForecast([FromBody]WeatherForecast weatherForecast)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeiqueuestorage;AccountKey=1ODKcSiD/5rQPDtwRi0ADHNf0P27/PGUt0i7gY+CjO9Z7tr40fqBuPHUPQk1hhD6+YV6XUrq/WTQ+AStocDEdw==;EndpointSuffix=core.windows.net";
            string queueName = "add-weather-data";
            var queue = new AzureQueue(connectionString, queueName);
            string message = JsonSerializer.Serialize(weatherForecast);
            await queue.SendMessage(message, 0, 3000);
        }
    }
}
