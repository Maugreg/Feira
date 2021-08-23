using Feira.Api.Application.Commands.FeiraCommands.Buscar;
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
    public class BuscarFiltroCommandHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public BuscarFiltroCommandHandlerTests()
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
        public async Task BuscarFiltroCommandHandler_Should_Return_True()
        {
            // Arrange
            var buscarFiltroCommandHandler = this.CreateBuscarFiltroCommandHandler();
            BuscarFiltroCommand request = new BuscarFiltroCommand() { Bairro = "Bairro", Distrito = "Distrito", Nome_Feira = "Nome_Feira", Regiao5 = "Regiao5" };
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            var list = new List<Domain.Entities.Feira>();
            list.Add(Scenario.Scenario.Feira);

            this.mockFeiraRepository.Setup(x => x.BuscarFiltroAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(list);

            // Act
            var result = await buscarFiltroCommandHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.True(result.Any());
            this.mockRepository.VerifyAll();
        }
    }
}
