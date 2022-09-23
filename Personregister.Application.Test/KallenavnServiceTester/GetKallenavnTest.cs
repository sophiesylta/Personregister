using Microsoft.EntityFrameworkCore;
using Moq;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Application.Test.KallenavnServiceTester
{
    public class GetKallenavnTest
    {
        Personregistercontext personregistercontext;
        IPersonRepository personrepository;
        IKallenavnRepository kallenavnRepository;
        public GetKallenavnTest()
        {
            //kallenavnRepository = new Mock<IKallenavnRepository>();
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            kallenavnRepository = new KallenavnRepository(personregistercontext);
            personrepository = new PersonRepository(personregistercontext);
        }

        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestAtKallenavnBlirGenerert()
        {
            KallenavnService kallenavnService = new KallenavnService(kallenavnRepository);
            var kallenavnet=kallenavnService.getKallenavn("Fornavn", "Etternavn");
            Assert.True(!string.IsNullOrEmpty(kallenavnet));
        }

        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestLengdeKallenavnMin2()
        {
            KallenavnService kallenavnService = new KallenavnService(kallenavnRepository);
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
            KallenavnService kallenavnService = new KallenavnService(kallenavnRepository);
            var kallenavnet = kallenavnService.getKallenavn(fornavn, etternavn);
            Assert.True (kallenavnet.Length >= minLengde);
        }

        [Theory]
        [Trait("KallenavnService", "KallenavnService")]
        [InlineData("Donald", "", 2)]
        [InlineData("Donald", null, 2)]
        public void TestTomNavn(string fornavn, string etternavn, int minLengde)
        {
            KallenavnService kallenavnService = new KallenavnService(kallenavnRepository);
            var kallenavnet = kallenavnService.getKallenavn(fornavn, etternavn);
            Assert.True(kallenavnet.Length >= minLengde);
        }

        [Fact]
        [Trait("KallenavnService", "KallenavnService")]
        public void TestGirUnikeKallenavn()
        {
            /* lager vår egn mockList for kallenavn */
            List<string> kallenavnListe = new List<string>();

            Mock<IKallenavnRepository> kallenavnRepository = new Mock<IKallenavnRepository>();
            kallenavnRepository.Setup(e=>e.getKallenavnListe(It.IsAny<string>())).Returns((string s)=> kallenavnListe.Where(e=>e.Contains(s)).OrderByDescending(e => e).ToList());

            KallenavnService kallenavnService = new KallenavnService(kallenavnRepository.Object);

            kallenavnListe.Add(kallenavnService.getUniktKallenavn("dodu"));
            kallenavnListe.Add(kallenavnService.getUniktKallenavn("habu"));
            kallenavnListe.Add(kallenavnService.getUniktKallenavn("dodu"));

            kallenavnListe.Add(kallenavnService.getUniktKallenavn("dodu"));
            kallenavnListe.Add(kallenavnService.getUniktKallenavn("habu"));
            kallenavnListe.Add(kallenavnService.getUniktKallenavn("dodu"));
            kallenavnListe.Add(kallenavnService.getUniktKallenavn("habu"));

            int antallUlikeKallenavn = kallenavnListe.Distinct().Count();
            Assert.Equal(kallenavnListe.Count, antallUlikeKallenavn);

 //           Assert.False(kallenavnet1.Equals(kallenavnet2));
        }

      



    }
}