using Microsoft.EntityFrameworkCore;
using Personregister.Application;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;

namespace Personregister.Infrastructure.Persistence.Test.Repository.DødsfallRepositoryTester
{
    public class AddPersonTest
    {
        PersonRepository personRepository;
        Personregistercontext personregistercontext;
        IKallenavnService kallenavnService;
        INavnService navnService;

        public AddPersonTest()
        {
            kallenavnService = new KallenavnService();
            navnService = new NavnService();
            //1 Lage context med SQL-Server.
            //2 . Bruke en annen database. f.eks SQLLite ...
            //3 bruke InMemory -data  (noe begrenset funksjonalitet...
        
            personregistercontext = new Personregistercontext(new DbContextOptionsBuilder<Personregistercontext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            personRepository = new PersonRepository(personregistercontext);
        }

        [Fact]
        [Trait("PersonRepository", "PersonRepository")]
        public void LeggTilPerson()
        {
            var person = nyPerson();
            personRepository.add(person);

            Assert.Equal(1, personregistercontext.Personer.Count());
        }


        [Fact]
        [Trait("PersonRepository", "PersonRepository")]
        public void LeggTilFlerePersoner()
        {
            int antall = 10;
            long personnnummer = 11111111111;
            for(int i=0;i<antall;i++)
            {
                Person person = new Person()
                {
                    Personnummer = personnnummer,
                    Fornavn = "",
                    Etternavn = ""
                };
                personRepository.add(person);
                personnnummer++;
            }

            Assert.Equal(antall, personregistercontext.Personer.Count());
        }

        [Fact]
        [Trait("PersonRepository", "PersonRepository")]
        public void LeggTilPersonSomFinnesFraFør() 
        {
            Person person = nyPerson();
            personRepository.add(person);
            personRepository.add(person);

            Assert.Equal(1, personregistercontext.Personer.Count());
        }

        public Person nyPerson()
        {
            var person = new Person()
            {
                Fornavn = "Donald",
                Etternavn = "Duck",
                Personnummer = 77889944556
            };
            return person;
            
        }


    }
}