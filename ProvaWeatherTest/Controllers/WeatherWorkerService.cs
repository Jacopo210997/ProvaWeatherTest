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

        public async Task Delete(int id)
        {
            var weatherRemove = await _ctx.Weathers.SingleOrDefaultAsync(weather => weather.Id == id);
            _ctx.Weathers.Remove(weatherRemove);
            _ctx.SaveChanges();
        }

        public Task<List<WeatherForecast>> Get()
        {
            return _ctx.Weathers.ToListAsync();
        }

        public Task<WeatherForecast> Get(int id)
        {
            return _ctx.Weathers.SingleAsync(weather => weather.Id == id);
        }

        public async Task<WeatherForecast> Insert(WeatherForecast weather)
        {
            _ctx.Add(weather);
            await _ctx.SaveChangesAsync();
            return weather;
        }
    }
}
