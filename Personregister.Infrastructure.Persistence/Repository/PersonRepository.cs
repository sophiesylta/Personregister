using Personregister.Domene;
using Personregister.Domene.Repository;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Personregistercontext personregistercontext;

        public PersonRepository(Personregistercontext personregistercontext)
        {

            this.personregistercontext = personregistercontext;
            //this.personregistercontext.Database.EnsureCreated();

            if (personregistercontext.Personer.Count() == 0)
            {
                this.personregistercontext.Personer.Add(new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 });
                this.personregistercontext.Personer.Add(new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 });

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
