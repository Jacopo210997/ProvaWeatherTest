using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProvaWeatherTest;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Test;
using Xunit;

namespace Tests
{
    public class ControllerWeatherTest : IntegrationTest
    {
        //Campo privato che simula le request da parte di un Client
        

        //Controller che injecta la WebApplicationFactory che runna l'API nel Test
        public ControllerWeatherTest(CustomWebApplicationFactory fixture) : base(fixture)
        {
        }
        [Fact]
        public async Task GetWeather()
        {
            var response = await _client.GetAsync("/weatherforecast");          //In questa riga, mandiamo una http Get Request al controller che mi dà una Response
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);      //qui controllo se lo status code della response è 200

            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(7);
        }
    }
}