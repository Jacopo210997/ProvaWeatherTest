//using Microsoft.Extensions.Configuration;
//using Respawn;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Test;
//using Xunit;

//public abstract class IntegrationTest : IClassFixture<CustomWebApplicationFactory>
//{
//    private readonly Checkpoint _checkpoint = new Checkpoint
//    {
        
//        SchemasToInclude = new[] {
//            "Playground"
//        },
//        WithReseed = true
//    };

//    protected readonly CustomWebApplicationFactory _factory;
//    protected readonly HttpClient _client;

//    public IntegrationTest(CustomWebApplicationFactory fixture)
//    {
//        _factory = fixture;
//        _client = _factory.CreateClient();

        
//        _checkpoint.Reset(_factory.Configuration.GetConnectionString("DefaultConnection")).Wait();
//    }
//}
