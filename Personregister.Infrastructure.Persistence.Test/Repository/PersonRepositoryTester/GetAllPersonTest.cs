using Microsoft.EntityFrameworkCore;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.DødsfallRepositoryTester
{
    public class GetAllPersonTest
    {
        PersonRepository personRepository;
        Personregistercontext personregistercontext;

        public GetAllPersonTest()
        {
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            personRepository = new PersonRepository(personregistercontext);
        }

        [Fact]
        [Trait("PersonRepository", "PersonRepository")]
        public void GetAllePersonerTest()
        {
            Person person1 = new Person(78945612312)
            {
                Fornavn = "fornavn1",
                Etternavn = "etternavn1"
            };
            personRepository.add(person1);

            Person person2 = new Person(78978945645)
            {
                Fornavn = "fornavn2",
                Etternavn = "etternavn2"
            };
            personRepository.add(person2);

            Assert.Equal(2, personRepository.getAll().Count());

        }
    }
}