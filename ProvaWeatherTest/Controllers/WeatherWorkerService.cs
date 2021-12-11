using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaWeatherTest.Controllers
{
    public class WeatherWorkerService : IWeatherWorkerService
    {
        private readonly WeatherDbContext _ctx;

        public WeatherWorkerService(WeatherDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Summary = "Giorgio merda"
                }
            };
        }
    }
}
