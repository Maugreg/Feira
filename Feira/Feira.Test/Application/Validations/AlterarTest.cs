using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Api.Application.Validations;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Feira.Test.Application.Validations
{
    public class AlterarTest
    {

        [Fact]
        public async Task AlterarValidatorTest()
        {
            var command = new AlterarCommand(Scenario.Scenario.alterarRequest, 334);

            var customerValidator = await new AlterarValidator().ValidateAsync(command).ConfigureAwait(false);

            Assert.True(customerValidator.IsValid);
        }
    }
}
