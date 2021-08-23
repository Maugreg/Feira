using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.FeiraCommands.Buscar
{
    public class BuscarFiltroCommand : IRequest<List<Feira.Domain.Entities.Feira>>
    {
        public string Distrito { get; set; }
        public string Regiao5 { get; set; }
        public string Nome_Feira { get; set; }
        public string Bairro { get; set; }
    }
}
