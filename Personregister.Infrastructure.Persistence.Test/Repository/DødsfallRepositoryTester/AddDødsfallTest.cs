using Microsoft.EntityFrameworkCore;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.D�dsfallRepositoryTester
{
    public class AddD�dsfallTest
    {
        D�dsfallRepository d�dsfallRepository;
        Personregistercontext personregistercontext;

        public AddD�dsfallTest()
        {
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            d�dsfallRepository = new D�dsfallRepository(personregistercontext);
        }

        [Fact]
        [Trait("D�dsfallRepository", "D�dsfallRepository")]
        public void LeggTilD�dsfall()
        {
            D�dsfall d�dsfall = new D�dsfall()
            {
                d�ds�rsak=""
            };
            d�dsfallRepository.add(d�dsfall);

            Assert.Equal(1, personregistercontext.D�dsfall.Count());
        }


        [Fact]
        [Trait("D�dsfallRepository", "D�dsfallRepository")]
        public void LeggTilFlereD�dsfall()
        {
            int antall = 10;
            for(int i=0;i<antall;i++)
            {
                D�dsfall d�dsfall = new D�dsfall()
                {
                    d�ds�rsak = ""
                };
                d�dsfallRepository.add(d�dsfall);

            }

            Assert.Equal(antall, personregistercontext.D�dsfall.Count());
        }


    }
}