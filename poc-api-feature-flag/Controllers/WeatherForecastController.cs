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
            string[] users = { "client_a", "client_b" };

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                user = users[index % 2],
                isFeatureActive = _featureManager.isFeatureActivated("featureA", users[index % 2])
            }).ToArray();
        }
    }
}
