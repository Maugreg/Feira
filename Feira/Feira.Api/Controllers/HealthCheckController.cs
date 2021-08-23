using Feira.Api.Application.Commands.HealthCheck;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using System.Threading.Tasks;

namespace Feira.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public HealthCheckController(IMediator mediator,
            ILogger logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("application")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Application()
        {
            return Ok();
        }


        [HttpGet("dbMysql")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CheckDataBaseSqlServerStatusAsync()
        {
            await _mediator.Send(new CheckMySqlCommand())
                    .ConfigureAwait(false);

            return Ok();
        }

     
    }
}
