using Feira.Api.Application.Commands.FeiraCommands.Buscar;
using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Api.Controllers;
using Feira.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Controllers
{
    public class FeiraControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IMediator> mockMediator;

        public FeiraControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMediator = this.mockRepository.Create<IMediator>();
        }

        private FeiraController CreateFeiraController()
        {
            return new FeiraController(
                this.mockMediator.Object);
        }

        [Fact]
        public async Task Inserir_Should_Return_OK()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            InserirCommand command = null;

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<InserirCommand>(), cancellationToken)).ReturnsAsync(true);

            // Act
            var result = await feiraController.Inserir(
                command);

            // Assert
            Assert.IsType<OkResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task Inserir_Should_Return_BadRequest()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            InserirCommand command = null;

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<InserirCommand>(), cancellationToken)).ReturnsAsync(false);

            // Act
            var result = await feiraController.Inserir(
                command);

            // Assert
            Assert.IsType<BadRequestResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task Excluir_Should_Return_OK()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            int id = 0;

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<ExcluirCommand>(), cancellationToken)).ReturnsAsync(true);

            // Act
            var result = await feiraController.Excluir(
                id);

            // Assert
            Assert.IsType<OkResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task Excluir_Should_Return_BadRequest()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            int id = 0;

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<ExcluirCommand>(), cancellationToken)).ReturnsAsync(false);

            // Act
            var result = await feiraController.Excluir(
                id);

            // Assert
            Assert.IsType<BadRequestResult>(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Alterar_Should_Return_OK()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            int id = 0;
            AlterarRequest request = new AlterarRequest();

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<AlterarCommand>(), cancellationToken)).ReturnsAsync(true);

            // Act
            var result = await feiraController.Alterar(
                id,
                request);

            // Assert
            Assert.IsType<OkResult>(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Alterar_Should_Return_BadRequest()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            int id = 0;
            AlterarRequest request = new AlterarRequest();

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<AlterarCommand>(), cancellationToken)).ReturnsAsync(false);

            // Act
            var result = await feiraController.Alterar(
                id,
                request);

            // Assert
            Assert.IsType<BadRequestResult>(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task BuscarFiltro_Return_OK_Object()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            string distrito = "teste";
            string regiao5 = "teste";
            string nomeFeira = "teste";
            string bairro = "teste";

            var list = new List<Domain.Entities.Feira>();
            list.Add(Scenario.Scenario.Feira);

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<BuscarFiltroCommand>(), cancellationToken)).ReturnsAsync(list);

            // Act
            var result = await feiraController.BuscarFiltro(
                distrito,
                regiao5,
                nomeFeira,
                bairro);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task BuscarFiltro_Return_NotFound()
        {
            // Arrange
            var feiraController = this.CreateFeiraController();
            string distrito = "teste";
            string regiao5 = "teste";
            string nomeFeira = "teste";
            string bairro = "teste";

            var list = new List<Domain.Entities.Feira>();

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<BuscarFiltroCommand>(), cancellationToken)).ReturnsAsync(list);

            // Act
            var result = await feiraController.BuscarFiltro(
                distrito,
                regiao5,
                nomeFeira,
                bairro);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            this.mockRepository.VerifyAll();
        }
    }
}
