using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Domain.Exceptions;
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
    public class ExcluirCommandHandlerExceptionTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public ExcluirCommandHandlerExceptionTests()
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
        public async Task ExcluirCommandHandler_Should_Return_Business_Exception()
        {
            try
            {
                // Arrange
                var excluirCommandHandler = this.CreateExcluirCommandHandler();
                ExcluirCommand request = new ExcluirCommand() { id = 3 };
                CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
                Domain.Entities.Feira feira = null;

                this.mockFeiraRepository.Setup(x => x.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(feira);

                // Act
                var result = await excluirCommandHandler.Handle(
                    request,
                    cancellationToken);
            }
            catch (BusinessException ex)
            {
                // Assert
                Assert.Contains("Id não encontrada na base", ex.Message);
            }
        }
    }
}
