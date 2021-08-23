using Feira.Api.Application.Commands.FeiraCommands.Buscar;
using Feira.Domain.Exceptions;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.FeiraCommands.Buscar
{
    public class BuscarFiltroCommandHandlerExceptionTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public BuscarFiltroCommandHandlerExceptionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFeiraRepository = this.mockRepository.Create<IFeiraRepository>();
            this.mockLogger = new Mock<ILogger>();
        }

        private BuscarFiltroCommandHandler CreateBuscarFiltroCommandHandler()
        {
            return new BuscarFiltroCommandHandler(
                this.mockFeiraRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task BuscarFiltroCommandHandler_Should_Return_BusinessException()
        {
            try
            {
                // Arrange
                var buscarFiltroCommandHandler = this.CreateBuscarFiltroCommandHandler();
                BuscarFiltroCommand request = new BuscarFiltroCommand() { };
                CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

                var list = new List<Domain.Entities.Feira>();
                list.Add(Scenario.Scenario.Feira);

                this.mockFeiraRepository.Setup(x => x.BuscarFiltroAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(list);

                // Act
                var result = await buscarFiltroCommandHandler.Handle(
                    request,
                    cancellationToken);
            }
            catch (BusinessException ex)
            {
                // Assert
                Assert.Contains("Escolha pelo menos um parametro de busca", ex.Message);
            }
        }
    }
}
