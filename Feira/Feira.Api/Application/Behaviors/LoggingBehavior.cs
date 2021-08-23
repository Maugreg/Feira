using Feira.Api.Filters;
using Feira.Api.Infrastructure.Extensions;
using Feira.Domain.Extensions;
using MediatR;
using Serilog;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Feira.Api.Application.Behaviors
{
    [ExcludeFromCodeCoverage]
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _serilog;
        public LoggingBehavior(ILogger serilog)
        {
            _serilog = serilog;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _serilog.Information("Handling command {CommandName} ({@Command})", request.GetGenericTypeName(), request);
            var response = await next();
            _serilog.Information("Command {0} handled in {1} - response: {2}.",
                request.GetGenericTypeName(),
                stopwatch.Elapsed.NormalizeTimeSpan(),
                response.ToJson());

            return response;
        }
    }
}
