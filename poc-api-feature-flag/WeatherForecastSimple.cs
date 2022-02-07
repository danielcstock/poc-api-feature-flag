using System;

namespace poc_api_feature_flag
{
    public class WeatherForecastSimple: IWeatherForeacast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
