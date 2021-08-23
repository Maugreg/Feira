using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Controllers
{
    public class HealthCheckControllerTests : BaseApiTest
    {
        [Theory]
        [InlineData("GET")]
        public async Task Application_Should_Return_Success(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/v1/HealthCheck/application/");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }




        [Theory]
        [InlineData("GET")]
        public async Task CheckDataBaseMySqlStatusAsync_Should_Return_Success(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/v1/HealthCheck/dbMysql/");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
