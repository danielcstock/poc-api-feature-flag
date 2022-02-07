using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using poc_api_feature_flag.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<IWeatherForeacast> Get()
        {
            var rng = new Random();

            if (_featureManager.isFeatureActivated("getSummary"))
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            } else
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecastSimple
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55)
                })
                .ToArray();
            }
        }
    }
}
