using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Domain.Exceptions;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.FeiraCommands.Inserir
{
    public class InserirCommandHandlerExceptionTests
    {
        private MockRepository mockRepository;

        private Mock<IFeiraRepository> mockFeiraRepository;
        private Mock<ILogger> mockLogger;

        public InserirCommandHandlerExceptionTests()
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
        public async Task InserirCommandHandler_Should_Return_Business_Exception()
        {
            try
            {

            // Arrange
            var inserirCommandHandler = this.CreateInserirCommandHandler();
            InserirCommand request = Scenario.Scenario.inserirCommand;
            request.Areap = 0;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            this.mockFeiraRepository.Setup(x => x.InserirAsync(It.IsAny<Domain.Entities.Feira>())).ReturnsAsync(true);

            // Act
            var result = await inserirCommandHandler.Handle(
                request,
                cancellationToken);
            }
            catch (BusinessException ex)
            {

                // Assert
                string[] mylist = ex.ValidationError.Select(I => Convert.ToString(I.Message)).ToArray();

                Assert.Contains("Areap Igual a Zero não declarada", mylist);
            }

   
        }
    }
}
