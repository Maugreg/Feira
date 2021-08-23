using Feira.Api.Application.Commands.FeiraCommands.Alterar;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.FeiraCommands.Alterar
{
    public class AlterarCommandHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public AlterarCommandHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFeiraRepository = this.mockRepository.Create<IFeiraRepository>();
            this.mockLogger = new Mock<ILogger>();
        }

        private AlterarCommandHandler CreateAlterarCommandHandler()
        {
            return new AlterarCommandHandler(
                this.mockFeiraRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task AlterarCommandHandler_Should_Return_True()
        {
            // Arrange
            var alterarCommandHandler = this.CreateAlterarCommandHandler();
            AlterarCommand request = new AlterarCommand(Scenario.Scenario.alterarRequest,2);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            this.mockFeiraRepository.Setup(x => x.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(Scenario.Scenario.Feira);

            this.mockFeiraRepository.Setup(x => x.AlterarAsync(It.IsAny<Domain.Entities.Feira>())).ReturnsAsync(true);

            // Act
            var result = await alterarCommandHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
    }
}
