using Feira.Api.Application.Commands.HealthCheck;
using Feira.Domain.Interfaces.Repository;
using Moq;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Commands.HealthCheck
{
    public class CheckMySqlCommandHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<IHealthCheckRepository> mockHealthCheckRepository;
        private Mock<ILogger> mockLogger;

        public CheckMySqlCommandHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockHealthCheckRepository = this.mockRepository.Create<IHealthCheckRepository>();
            this.mockLogger = new Mock<ILogger>();
        }

        private CheckMySqlCommandHandler CreateCheckSqlServerCommandHandler()
        {
            return new CheckMySqlCommandHandler(
                this.mockHealthCheckRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var checkSqlServerCommandHandler = this.CreateCheckSqlServerCommandHandler();
            CheckMySqlCommand request = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);


            mockHealthCheckRepository.Setup(x => x.CheckDataBaseMySqlStatusAsync()).ReturnsAsync(true);

            // Act
            var result = await checkSqlServerCommandHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
    }
}
