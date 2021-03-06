using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaWeatherTest.Controllers
{
    public interface IWeatherWorkerService
    {
        Task<List<WeatherForecast>> Get();
        Task<WeatherForecast> Get(int id);
        Task<WeatherForecast> Insert(WeatherForecast weather);
        Task Delete(int id);

    }
}