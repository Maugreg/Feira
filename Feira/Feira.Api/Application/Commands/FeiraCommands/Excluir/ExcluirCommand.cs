using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.FeiraCommands.Excluir
{
    public class ExcluirCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
