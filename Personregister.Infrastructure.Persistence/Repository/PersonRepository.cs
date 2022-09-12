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
            
        }

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

            return person;
        }

        public List<Person> getAll()
        {
            //  return personListe;

            return personregistercontext.Personer.ToList();

        }

        public Person getPerson(long personnummer)
        {
            return personregistercontext.Personer.Where(e => e.Personnummer == personnummer).FirstOrDefault();
        }
    }
}
