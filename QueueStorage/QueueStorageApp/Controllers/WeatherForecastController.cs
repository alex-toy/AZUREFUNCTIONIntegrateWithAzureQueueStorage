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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

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

        [HttpPost]
        public async Task AddWeatherForecast([FromBody]WeatherForecast course)
        {
            // add course to a database

            //var courseAdded = new CourseAdded()
            //{
            //    Id = Guid.NewGuid(),
            //    CreatedDateTime = DateTime.Now,
            //    ForDate = course.Date,
            //};

            //string? body = JsonSerializer.Serialize(courseAdded);

            //var properties = new Dictionary<string, string>() {
            //    { "Month" , course.Date.ToString("MMMM")}
            //};
            //await _serviceBus.SendMessage(body, properties, 3000);
        }
    }
}
