using Microsoft.EntityFrameworkCore;
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
        public Task<List<WeatherForecast>> Get()
        {
            return _ctx.Weathers.ToListAsync();
        }

        public Task<WeatherForecast> Get(int id)
        {
            return _ctx.Weathers.SingleAsync(weather => weather.Id == id);
        }
    }
}
