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
        KallenavnRepository kallenavnRepository;
        IKallenavnService kallenavnService;
        INavnService navnService;

        public AddPersonTest()
        {
            kallenavnRepository = new KallenavnRepository(personregistercontext);
            kallenavnService = new KallenavnService(kallenavnRepository);
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
                Person person = new Person(personnnummer)
                {
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
            Person person1 = nyPerson();
            personRepository.add(person1);
            Person person2 = nyPerson();
            personRepository.add(person2);
            personregistercontext.SaveChanges();

            //Fungerer ikke pga inMemory database?
            Assert.Equal(2, personregistercontext.Personer.Count());
        }

        public Person nyPerson()
        {
            var person = new Person(77889944556)
            {
                Fornavn = "Donald",
                Etternavn = "Duck",
            };
            return person;
            
        }


    }
}