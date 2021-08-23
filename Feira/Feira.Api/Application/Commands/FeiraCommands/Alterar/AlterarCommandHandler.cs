using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Domain.Interfaces.Repository;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.FeiraCommands.Alterar
{
    public class AlterarCommandHandler : IRequestHandler<AlterarCommand, bool>
    {
        private readonly IFeiraRepository _feiraRepository;
        private readonly ILogger _logger;

        public AlterarCommandHandler(IFeiraRepository feiraRepository, ILogger logger)
        {
            _feiraRepository = feiraRepository;
            _logger = logger.ForContext<AlterarCommandHandler>();
        }


        /// <summary>
        /// Evento para alterar as propriedades da entidade feira
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(AlterarCommand request, CancellationToken cancellationToken)
        {

            var entity = await _feiraRepository.BuscarPorIdAsync(request.Id);

            if (entity == null)
            {
                throw new Feira.Domain.Exceptions.BusinessException("Id não encontrada na base");
            }

            var feira = new Feira.Domain.Entities.Feira(request);
            feira.ID = request.Id;

            return await _feiraRepository.AlterarAsync(feira);
        }
    }
}
