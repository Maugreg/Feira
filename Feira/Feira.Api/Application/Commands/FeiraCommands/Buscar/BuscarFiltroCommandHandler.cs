using Feira.Api.Application.Commands.FeiraCommands.Buscar;
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

namespace Feira.Api.Application.Commands.FeiraCommands.Buscar
{
    public class BuscarFiltroCommandHandler : IRequestHandler<BuscarFiltroCommand, List<Feira.Domain.Entities.Feira>>
    {
        private readonly IFeiraRepository _feiraRepository;
        private readonly ILogger _logger;

        public BuscarFiltroCommandHandler(IFeiraRepository feiraRepository, ILogger logger)
        {
            _feiraRepository = feiraRepository;
            _logger = logger.ForContext<BuscarFiltroCommandHandler>();
        }


        /// <summary>
        /// Metodo de Buscar feira por filtro 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Feira.Domain.Entities.Feira>> Handle(BuscarFiltroCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Bairro) && string.IsNullOrEmpty(request.Distrito) && string.IsNullOrEmpty(request.Nome_Feira) && string.IsNullOrEmpty(request.Regiao5))
            {
                throw new Feira.Domain.Exceptions.BusinessException("Escolha pelo menos um parametro de busca.");
            }


            var entity = await _feiraRepository.BuscarFiltroAsync(request.Distrito, request.Regiao5, request.Nome_Feira, request.Bairro);

            return entity;
        }
    }
}
