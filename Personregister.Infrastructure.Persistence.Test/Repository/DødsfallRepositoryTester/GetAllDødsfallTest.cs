using Microsoft.EntityFrameworkCore;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.D�dsfallRepositoryTester
{
    public class GetAllD�dsfallTest
    {
        D�dsfallRepository d�dsfallRepository;
        Personregistercontext personregistercontext;

        public GetAllD�dsfallTest()
        {
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            d�dsfallRepository = new D�dsfallRepository(personregistercontext);
        }

        [Fact]
        [Trait("D�dsfallRepository", "D�dsfallRepository")]
        public void PerssonSkalV�reUtfylt()
        {
            D�dsfall d�dsfall = new D�dsfall()
            {
                d�ds�rsak="",
                person=new Person("22.01.90") { CreateAt = DateTime.Now , Fornavn="",Etternavn="" },
            };
            d�dsfallRepository.add(d�dsfall);

            Assert.Equal(1, personregistercontext.D�dsfall.Count());

            var d�dsfallIDB=personregistercontext.D�dsfall.First();

            Assert.NotNull(d�dsfallIDB.person);

        }


       


    }
}