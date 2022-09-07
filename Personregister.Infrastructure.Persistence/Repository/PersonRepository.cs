using Personregister.Application;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Personregistercontext personregistercontext;

        public PersonRepository(Personregistercontext personregistercontext, INavnService navnService)
        {

            this.personregistercontext = personregistercontext;
            //this.personregistercontext.Database.EnsureCreated();

            if (personregistercontext.Personer.Count() == 0)
            {
                (string fornavn, string etternavn) = navnService.getNavn(12312312312);
                this.personregistercontext.Personer.Add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = 12312312312 });
                (fornavn, etternavn) = navnService.getNavn(23423423423);
                this.personregistercontext.Personer.Add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = 23423423423 });

                this.personregistercontext.SaveChanges();
            }
        }

        //private List<Person> personListe = new List<Person>()
        //{
        //    new Person(){Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 },
        //    new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }
        //};


        public Person add(Person person)
        {
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            var p = personregistercontext.Personer.FirstOrDefault(e => e.Personnummer == person.Personnummer);

            if (p != null) 
            {
                return person;    
            }

            personregistercontext.Personer.Add(person);
            personregistercontext.SaveChanges();
            //   personListe.Add(person);

            return person;
        }

        public List<Person> getAll()
        {
            //  return personListe;

            return personregistercontext.Personer.ToList();

        }
    }
}
