using Microsoft.EntityFrameworkCore;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.DødsfallRepositoryTester
{
    public class AddDødsfallTest
    {
        DødsfallRepository dødsfallRepository;
        Personregistercontext personregistercontext;

        public AddDødsfallTest()
        {
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            dødsfallRepository = new DødsfallRepository(personregistercontext);
        }

        [Fact]
        [Trait("DødsfallRepository", "DødsfallRepository")]
        public void LeggTilDødsfall()
        {
            Dødsfall dødsfall = new Dødsfall()
            {
                dødsårsak=""
            };
            dødsfallRepository.add(dødsfall);

            Assert.Equal(1, personregistercontext.Dødsfall.Count());
        }


        [Fact]
        [Trait("DødsfallRepository", "DødsfallRepository")]
        public void LeggTilFlereDødsfall()
        {
            int antall = 10;
            for(int i=0;i<antall;i++)
            {
                Dødsfall dødsfall = new Dødsfall()
                {
                    dødsårsak = ""
                };
                dødsfallRepository.add(dødsfall);

            }

            Assert.Equal(antall, personregistercontext.Dødsfall.Count());
        }


    }
}