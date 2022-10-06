using System.Security.Cryptography.X509Certificates;

namespace Personregister.Application.Test.NavnServiceTester
{
    public class GetNavnTest
    {
        NavnService navnService = new NavnService();

        [Theory]
        [InlineData(12312312312, "Sophie", "Sylta")]
        [InlineData(23423423423, "Trond", "Århus")]
        [InlineData(11111111111, "Donald", "Duck")]
        [InlineData(22222222222, "Minnie", "Mouse")]
        [Trait("NavnService", "NavnService")]
        public void GetKjentNavnTest(long personnummer, string forventetFornavn, string ForventetEtternavn)
        {

            var (fornavn, etternavn) = navnService.getNavn(personnummer);
            Assert.Equal(fornavn, forventetFornavn);
            Assert.Equal(etternavn, ForventetEtternavn);
        }

        [Fact]
        [Trait("NavnService", "NavnService")]
        public void getUkjentNavnTest()
        {
            var (fornavn, etternavn) = navnService.getNavn(8888888888);
            Assert.Equal(fornavn, "Ukjent");
            Assert.Equal(etternavn, "Ukjent");
        }

    }
}