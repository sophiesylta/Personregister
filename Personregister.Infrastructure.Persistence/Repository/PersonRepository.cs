using Personregister.Application;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Personregistercontext personregistercontext;
        

        public PersonRepository(Personregistercontext personregistercontext)
        {

            this.personregistercontext = personregistercontext;

        }

        public Person add(Person person)
        {

            personregistercontext.Personer.Add(person);
            personregistercontext.SaveChanges();

            return person;
        }

        public List<Person> getAll()
        {

            return personregistercontext.Personer.ToList();

        }

        public Person getPerson(long personnummer)
        {
            return personregistercontext.Personer.Where(e => e._Fødselsnummer.Equals (personnummer.ToString())).FirstOrDefault();
        }
        public Person getPersonByKallenavn(string kallenavn)
        {
            return personregistercontext.Personer.Where(e => e.Kallenavn.Equals(kallenavn)).FirstOrDefault();
        }

        public Person edit(Person person)
        {
            personregistercontext.Update(person);
            personregistercontext.SaveChanges();
            return person;
        }
    }
}
