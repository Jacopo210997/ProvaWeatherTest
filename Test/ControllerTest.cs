using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProvaWeatherTest;
using ProvaWeatherTest.Controllers;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Test;
using Xunit;

namespace Tests
{
    public class ControllerWeatherTest : IntegrationTest
    {
        //Campo privato che simula le request da parte di un Client


        //Controller che injecta la WebApplicationFactory che runna l'API nel Test

        public ControllerWeatherTest(CustomWebApplicationFactory factory) : base(factory)
        {
            
        }

        [Fact]
        public async void GetWeatherAll()
        {
                var ctx = await SetupDbContext();
                var weather = new WeatherForecast
                {
                    Summary = "Giorgio merda"
                };
                ctx.Weathers.Add(weather);
                await ctx.SaveChangesAsync();
                var response = await _client.GetAsync("weathersforecast");          //In questa riga, mandiamo una http Get Request al controller che mi d? una Response
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);      //qui controllo se lo status code della response ? 200
                var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());

                forecast.Should().HaveCount(1);
        }

        [Fact]
        public async void GetWeatherById()
        {
            var ctx = await SetupDbContext();
            
            var weather = new WeatherForecast
            {
                Summary = "Giorgio merda"
            };
            ctx.Weathers.Add(weather);
            await ctx.SaveChangesAsync();
            var response = await _client.GetAsync("/weathersforecast/" + weather.Id);          //In questa riga, mandiamo una http Get Request al controller che mi d? una Response
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var forecast = JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());
            forecast.Id.Should().Be(weather.Id);
        }

        [Fact]
        public async void PostWeather()
        {
            var ctx = await SetupDbContext();

            var weather = new WeatherForecast
            {
                Summary = "Giorgio merda"
            };
            var json = JsonConvert.SerializeObject(weather);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("weathersforecast/",httpContent);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            var objectTask = await response.Content.ReadAsAsync<WeatherForecast>();
            ctx.Weathers.SingleOrDefaultAsync(weather => weather.Id == objectTask.Id).Should().NotBeNull();
        }

        [Fact]
        public async void DeleteTest()
        {
            var ctx = await SetupDbContext();

            var weather = new WeatherForecast
            {
                Summary = "Giorgio merda"
            };

            ctx.Weathers.Add(weather);
            await ctx.SaveChangesAsync();
            var response = await _client.DeleteAsync("weathersforecast/" + weather.Id);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            ctx.Weathers.SingleOrDefaultAsync(weatherOriginal => weatherOriginal.Id == weather.Id).Result.Should().BeNull();

        }

        private async Task<WeatherDbContext> SetupDbContext()
        {
            var ctx = _factory
                .Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<WeatherDbContext>();

            await ctx.Database.EnsureDeletedAsync();
            await ctx.Database.EnsureCreatedAsync();
            var originalEntities = ctx.Weathers
               .ToList();

            //una volta recuperati li rimuovo come se fosse una normale collezione
            ctx.Weathers.RemoveRange(originalEntities);

            //...dopodich? salvo le modifiche con un comando SQL
            await ctx.SaveChangesAsync();

            //resetto l'id autoincrementale sulle tabelle Products e Producers
            await ctx.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Weathers', RESEED, 1)");
            await ctx.SaveChangesAsync();
            return ctx;
        }
    }
}