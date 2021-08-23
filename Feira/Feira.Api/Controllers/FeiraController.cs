
using Feira.Api.Application.Commands.FeiraCommands.Buscar;
using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Feira.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FeiraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeiraController(
          IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        /// <summary>
        /// Rota responsável por inserir uma nova Feira
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Inserir([FromBody] InserirCommand command)
        {
            var commandResult = await _mediator.Send(command).ConfigureAwait(false);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }


        /// <summary>
        /// Rota responsável pela exclusão de uma feira pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Excluir(int id)
        {
            var commandResult = await _mediator.Send(new ExcluirCommand() {  id = id }).ConfigureAwait(false);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }


        /// <summary>
        /// Rota responsável por alterar as informações da feira
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Alterar(int id,[FromBody] AlterarRequest request)
        {

            var commandResult = await _mediator.Send(new AlterarCommand(request, id)).ConfigureAwait(false);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }


        /// <summary>
        /// Rota que retorna uma lista de feira conforme o parametro utilizado
        /// </summary>
        /// <param name="distrito"></param>
        /// <param name="regiao5"></param>
        /// <param name="nomeFeira"></param>
        /// <param name="bairro"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> BuscarFiltro(string distrito, string regiao5, string nomeFeira, string bairro)
        {

            var commandResult = await _mediator.Send(new BuscarFiltroCommand() { Distrito = distrito, Regiao5 = regiao5, Bairro = bairro, Nome_Feira = nomeFeira  }).ConfigureAwait(false);

            if (!commandResult.Any())
            {
                return NotFound();
            }

            return Ok(commandResult);
        }
    }
}
