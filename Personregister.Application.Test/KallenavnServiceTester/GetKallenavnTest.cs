namespace Personregister.Application.Test.KallenavnServiceTester
{
    public class GetKallenavnTest
    {
        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestAtKallenavnBlirGenerert()
        {
            KallenavnService kallenavnService = new KallenavnService();
            var kallenavnet=kallenavnService.getKallenavn("Fornavn", "Etternavn");
            Assert.True(!string.IsNullOrEmpty(kallenavnet));
        }

        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestLengdeKallenavnMin2()
        {
            KallenavnService kallenavnService = new KallenavnService();
            var kallenavnet = kallenavnService.getKallenavn("Fornavn", "Etternavn");
            Assert.True(kallenavnet.Length >= 2);
        }

        [Theory]
        [Trait("KallenavnService", "KallenavnService")]
        [InlineData("D", "D", 2)]
        [InlineData("D","Duck",3)]
        [InlineData("Donald", "D", 3)]
        [InlineData("Donald","Duck", 4)]

        public void TestLengdeKallenavn(string fornavn, string etternavn, int minLengde)
        {
            KallenavnService kallenavnService = new KallenavnService();
            var kallenavnet = kallenavnService.getKallenavn(fornavn, etternavn);
            Assert.True (kallenavnet.Length >= minLengde);
        }

        [Theory]
        [Trait("KallenavnService", "KallenavnService")]
        [InlineData("Donald", "", 2)]
        [InlineData("Donald", null, 2)]
        public void TestTomNavn(string fornavn, string etternavn, int minLengde)
        {
            KallenavnService kallenavnService = new KallenavnService();
            var kallenavnet = kallenavnService.getKallenavn(fornavn, etternavn);
            Assert.True(kallenavnet.Length >= minLengde);
        }

        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestGirUnikeKallenavn()
        {
            KallenavnService kallenavnService = new KallenavnService();
            var kallenavnet1= kallenavnService.getKallenavn("Donald", "Duck");
            var kallenavnet2 = kallenavnService.getKallenavn("Dolly", "Duck");

            Assert.False(kallenavnet1.Equals(kallenavnet2));
        }



    }
}