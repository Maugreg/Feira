using Feira.Domain.Enums;
using Feira.Domain.Interfaces;
using Feira.Repository;
using Feira.Test.Commom;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test
{
    public class FeiraRepositoryTests
    {
        private MockRepository mockRepository;

        private readonly Configuration _config = new Configuration();
        private Mock<IWrapperDbConnection> mockWrapperDbConnection;

        public FeiraRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockWrapperDbConnection = this.mockRepository.Create<IWrapperDbConnection>();
        }

        private FeiraRepository CreateFeiraRepository()
        {
            this.mockWrapperDbConnection
               .Setup(w => w.GetNewInstance(It.IsAny<DbConnectionInfoType>(), It.IsAny<string>()))
               .Returns(default(IDbConnection));

            return new FeiraRepository(
                _config,
                this.mockWrapperDbConnection.Object);
        }


        [Fact]
        public async Task BuscarPorIdAsync_Should_Return_ID_Greater_Then_Zero()
        {
            // Arrange
            var feiraRepository = this.CreateFeiraRepository();
            int id = 3;

            this.mockWrapperDbConnection.Setup(x => x.QueryFirstOrDefaultAsync<Feira.Domain.Entities.Feira>(It.IsAny<IDbConnection>(),
                It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(Scenario.Scenario.Feira);

            // Act
            var result = await feiraRepository.BuscarPorIdAsync(
                id);

            // Assert
            Assert.True(result.ID > 0);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task BuscarFiltroAsync_Should_Return_List_Any()
        {
            // Arrange
            var feiraRepository = this.CreateFeiraRepository();
            string distrito = "distrito";
            string regiao5 = "regiao5";
            string nomeFeira = "nomeFeira";
            string bairro = "bairro";

            var list = new List<Domain.Entities.Feira>();
            list.Add(Scenario.Scenario.Feira);

            this.mockWrapperDbConnection.Setup(x => x.QueryAsync<Feira.Domain.Entities.Feira>(It.IsAny<IDbConnection>(),
                  It.IsAny<string>(), It.IsAny<object>()))
                  .ReturnsAsync(list);

            // Act
            var result = await feiraRepository.BuscarFiltroAsync(
                distrito,
                regiao5,
                nomeFeira,
                bairro);

            // Assert
            Assert.True(result.Any());
            this.mockRepository.VerifyAll();
        }


    }
}
