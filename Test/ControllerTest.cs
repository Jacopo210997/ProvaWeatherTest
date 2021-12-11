using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProvaWeatherTest;
using ProvaWeatherTest.Controllers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Test;
using Xunit;

namespace Tests
{
    public class ControllerWeatherTest : IClassFixture<CustomWebApplicationFactory>
    {
        //Campo privato che simula le request da parte di un Client


        //Controller che injecta la WebApplicationFactory che runna l'API nel Test
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public ControllerWeatherTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task GetWeather()
        {
            var ctx = _factory
                .Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<WeatherDbContext>();
            var weather = new WeatherForecast
            {
                Summary = "Giorgio merda"
            };
            ctx.Weathers.Add(weather);
            var response = await _client.GetAsync("/weatherforecast");          //In questa riga, mandiamo una http Get Request al controller che mi dà una Response
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);      //qui controllo se lo status code della response è 200

            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(5);
        }
    }
}