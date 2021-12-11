using Microsoft.EntityFrameworkCore;

namespace ProvaWeatherTest.Controllers
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }
        public DbSet<WeatherForecast> Weathers { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
    }
}