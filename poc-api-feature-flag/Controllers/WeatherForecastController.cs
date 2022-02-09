using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using poc_api_feature_flag.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace poc_api_feature_flag.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IFeatureManager _featureManager;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _featureManager = new SplitIO();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                isFeatureActive = _featureManager.isFeatureActivated("getSummary")
            }).ToArray();
        }
    }
}
