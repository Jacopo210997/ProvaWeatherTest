using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaWeatherTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeathersForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IWeatherWorkerService _service;
        private readonly ILogger<WeathersForecastController> _logger;

        public WeathersForecastController(ILogger<WeathersForecastController> logger, IWeatherWorkerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost()]
        public async Task<IActionResult> PostWeather(WeatherForecast weatherRequest)
        {
            var weatherResponse = await _service.Insert(weatherRequest);
            return CreatedAtAction
                (
                    nameof(Get),
                    new { Id = weatherResponse.Id },
                    weatherResponse
                );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
        
    }
}
