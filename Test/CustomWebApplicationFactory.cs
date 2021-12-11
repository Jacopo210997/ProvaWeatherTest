using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProvaWeatherTest.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{

    public class CustomWebApplicationFactory : WebApplicationFactory<ProvaWeatherTest.Startup>
    {
        
        protected override IHostBuilder CreateHostBuilder() =>
            base.CreateHostBuilder().UseEnvironment("Testing");
    }
}


        //builder.ConfigureAppConfiguration(config =>
        //{
        //    Configuration = new ConfigurationBuilder()
        //        .AddJsonFile(@"C:\Users\jacop\source\repos\ProvaWeatherTest\ProvaWeatherTest\appsettings.Test.json")
        //        .Build();

//    config.AddConfiguration(Configuration);
//});

