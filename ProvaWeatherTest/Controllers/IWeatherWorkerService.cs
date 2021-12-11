using System.Collections.Generic;

namespace ProvaWeatherTest.Controllers
{
    public interface IWeatherWorkerService
    {
        public IEnumerable<WeatherForecast> Get();
    }
}