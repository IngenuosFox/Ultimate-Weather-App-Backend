﻿using Microsoft.AspNetCore.Mvc;
using Ultimate_Weather_App.Helpers;

namespace Ultimate_Weather_App.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherAPI weatherAPI;

        public WeatherController(IWeatherAPI weatherAPI)
        {
            this.weatherAPI = weatherAPI;
        }

        [HttpGet]
        [Route("WeatherForecast")]
        public async Task<ActionResult<string>> WeatherForecast([FromQuery] string latitude, [FromQuery] string longitude, [FromQuery] string units, [FromQuery] string language)
        {
            var result = await weatherAPI.GetWeatherInformation(latitude, longitude, units, language);
            return Ok(result);
        }

        [HttpGet]
        [Route("TemperaturePrevision")]
        public async Task<ActionResult<IEnumerable<Weather>>> TemperaturePrevision([FromQuery] string latitude, [FromQuery] string longitude, [FromQuery] string units, [FromQuery] int hours)
        {
            var result = await weatherAPI.GetTemperaturePrevision(latitude, longitude, units, hours);
            return Ok(result);
        }
    }
}
