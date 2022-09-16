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
        private readonly IKallenavnService kallenavnService;

        public PersonRepository(Personregistercontext personregistercontext, INavnService navnService, IKallenavnService kallenavnService)
        {

            this.personregistercontext = personregistercontext;
            this.kallenavnService = kallenavnService;
        }

        public Person add(Person person)
        {
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            var p = getPerson(person.Personnummer); 
            //personregistercontext.Personer.FirstOrDefault(e => e.Personnummer == person.Personnummer);

            if (p != null) 
            {
                return p;    
            }

            person.Kallenavn = kallenavnService.getKallenavn(person.Fornavn, person.Etternavn);

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
