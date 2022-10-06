using Microsoft.EntityFrameworkCore;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.DødsfallRepositoryTester
{
    public class GetAllDødsfallTest
    {
        DødsfallRepository dødsfallRepository;
        Personregistercontext personregistercontext;

        public GetAllDødsfallTest()
        {
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            dødsfallRepository = new DødsfallRepository(personregistercontext);
        }

        [Fact]
        [Trait("DødsfallRepository", "DødsfallRepository")]
        public void PerssonSkalVæreUtfylt()
        {
            Dødsfall dødsfall = new Dødsfall()
            {
                dødsårsak="",
                person=new Person("22.01.90") { CreateAt = DateTime.Now , Fornavn="",Etternavn="" },
            };
            dødsfallRepository.add(dødsfall);

            Assert.Equal(1, personregistercontext.Dødsfall.Count());

            var dødsfallIDB=personregistercontext.Dødsfall.First();

            Assert.NotNull(dødsfallIDB.person);

        }


       


    }
}