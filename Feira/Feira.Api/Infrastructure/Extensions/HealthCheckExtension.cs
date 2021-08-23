using Feira.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Infrastructure.Extensions
{

    [ExcludeFromCodeCoverage]
    public static class HealthCheckExtension
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, Settings settings)
        {
            services.AddHealthChecks()
                 .AddCheck("Aplicacao", () => HealthCheckResult.Healthy());

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic healthcheck", settings.BaseUrls.HealthUrl);
            }).AddInMemoryStorage();

            return services;
        }
    }
}
