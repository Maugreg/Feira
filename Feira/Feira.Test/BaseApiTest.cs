using Feira.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Feira.Test
{
    public class BaseApiTest
    {
        protected readonly HttpClient _client;

        public BaseApiTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<StartupTests>());
            _client = server.CreateClient();
        }
    }
}
