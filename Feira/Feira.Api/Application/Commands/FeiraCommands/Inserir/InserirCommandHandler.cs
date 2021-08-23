using Feira.Domain.Interfaces.Repository;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.FeiraCommands.Inserir
{
    public class InserirCommandHandler : IRequestHandler<InserirCommand, bool>
    {
        private readonly IFeiraRepository _feiraRepository;
        private readonly ILogger _logger;

        public InserirCommandHandler(IFeiraRepository feiraRepository, ILogger logger)
        {
            _feiraRepository = feiraRepository;
            _logger = logger.ForContext<InserirCommandHandler>();
        }

        /// <summary>
        /// Evento de inclusão de uma entidade feira
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(InserirCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Feira(request);
            return await _feiraRepository.InserirAsync(entity);
        }
    }
}
