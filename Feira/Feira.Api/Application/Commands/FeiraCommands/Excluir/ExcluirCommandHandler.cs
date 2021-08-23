using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Domain.Exceptions;
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
    public class ExcluirCommandHandler : IRequestHandler<ExcluirCommand, bool>
    {
        private readonly IFeiraRepository _feiraRepository;
        private readonly ILogger _logger;

        public ExcluirCommandHandler(IFeiraRepository feiraRepository, ILogger logger)
        {
            _feiraRepository = feiraRepository;
            _logger = logger.ForContext<InserirCommandHandler>();
        }

        /// <summary>
        /// Evento de exclusao de uma de uma feira
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(ExcluirCommand request, CancellationToken cancellationToken)
        {

            var entity = await _feiraRepository.BuscarPorIdAsync(request.id);

            if(entity == null)
            {
                throw new Feira.Domain.Exceptions.BusinessException("Id não encontrada na base");
            }

            return await _feiraRepository.ExcluirAsync(entity);
        }
    }
}
