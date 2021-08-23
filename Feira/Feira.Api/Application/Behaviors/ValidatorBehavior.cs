using Feira.Api.Filters;
using Feira.Api.Infrastructure.Extensions;
using Feira.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feira.Api.Application.Behaviors
{
    [ExcludeFromCodeCoverage]
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _serilog;
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger serilog)
        {
            _validators = validators;
            _serilog = serilog;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();

            _serilog.Information("Validating command {CommandType}", typeName);

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                _serilog.Warning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", typeName, request, failures);

                throw new BusinessException(
                    $"Erros de validação do Request: {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
            }

            return await next();
        }
    }
}
