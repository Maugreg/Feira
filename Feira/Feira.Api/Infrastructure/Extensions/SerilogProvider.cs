using Feira.Domain.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Infrastructure.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SerilogProvider
    {
        public static string Application => "Application";
        public static string CustomerCode => "customerCode";
        public static string Exception => "exception";
        public static string Operation => "operation";

        public static void CreateLogger(string serviceName, IConfiguration config)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log-.txt")
                .CreateLogger();

            Log.ForContext("application", serviceName)
                .ForContext(Operation, nameof(CreateLogger))
                .Information($"Log iniciado para aplicação:[{serviceName}] da data de: [{DateTime.Now}]");
        }
    }
}
