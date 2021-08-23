using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace Feira.Api
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            host.Run();
        }

        private static IWebHost CreateHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                       .CaptureStartupErrors(true)
                       .UseStartup<Startup>()
                       .Build();
    }
}
