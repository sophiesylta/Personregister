using Optional;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
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

        public Option<Person> getPersonOptional(long personnummer)
        {
            return personregistercontext.Personer.FirstOrDefault(e => e._Fødselsnummer.Equals(personnummer.ToString())).SomeNotNull()!;
        }

        public Option<Person> getPersonByKallenavn(string kallenavn)
        {
            return personregistercontext.Personer.FirstOrDefault(e => e.Kallenavn.Equals(kallenavn)).SomeNotNull()!;
        }

        public Person edit(Person person)
        {
            personregistercontext.Update(person);
            personregistercontext.SaveChanges();
            return person;
        }
    }
}
