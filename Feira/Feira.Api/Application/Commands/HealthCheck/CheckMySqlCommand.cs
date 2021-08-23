using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Application.Commands.HealthCheck
{
    public class CheckMySqlCommand : IRequest<bool>
    {
    }
}
