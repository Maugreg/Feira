using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.FeiraCommands.Inserir
{
    public class InserirCommandHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public InserirCommandHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFeiraRepository = this.mockRepository.Create<IFeiraRepository>();
            this.mockLogger = new Mock<ILogger>(); ;
        }

        private InserirCommandHandler CreateInserirCommandHandler()
        {
            return new InserirCommandHandler(
                this.mockFeiraRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task InserirCommandHandler_Should_Return_True()
        {
            // Arrange
            var inserirCommandHandler = this.CreateInserirCommandHandler();
            InserirCommand request = Scenario.Scenario.inserirCommand;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            this.mockFeiraRepository.Setup(x => x.InserirAsync(It.IsAny<Domain.Entities.Feira>())).ReturnsAsync(true);

            // Act
            var result = await inserirCommandHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
    }
}
