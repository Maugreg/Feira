using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.FeiraCommands.Excluir
{
    public class ExcluirCommandHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public ExcluirCommandHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFeiraRepository = this.mockRepository.Create<IFeiraRepository>();
            this.mockLogger = new Mock<ILogger>();
        }

        private ExcluirCommandHandler CreateExcluirCommandHandler()
        {
            return new ExcluirCommandHandler(
                this.mockFeiraRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task ExcluirCommandHandler_Should_Return_True()
        {
            // Arrange
            var excluirCommandHandler = this.CreateExcluirCommandHandler();
            ExcluirCommand request = new ExcluirCommand() { id = 3 };
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);


            this.mockFeiraRepository.Setup(x => x.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(Scenario.Scenario.Feira);

            this.mockFeiraRepository.Setup(x => x.ExcluirAsync(It.IsAny<Domain.Entities.Feira>())).ReturnsAsync(true);

            // Act
            var result = await excluirCommandHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
    }
}
