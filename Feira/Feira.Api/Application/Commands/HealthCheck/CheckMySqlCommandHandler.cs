using Feira.Domain.Interfaces.Repository;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.HealthCheck
{
    public class CheckMySqlCommandHandler : IRequestHandler<CheckMySqlCommand, bool>
    {
        private readonly IHealthCheckRepository _healthCheckRepository;
        private readonly ILogger _logger;

        public CheckMySqlCommandHandler(IHealthCheckRepository healthCheckRepository, ILogger logger)
        {
            _healthCheckRepository = healthCheckRepository;
            _logger = logger.ForContext<CheckMySqlCommandHandler>();
        }
        public async Task<bool> Handle(CheckMySqlCommand request, CancellationToken cancellationToken)
        {
            return await _healthCheckRepository.CheckDataBaseMySqlStatusAsync();
        }
    }
}
