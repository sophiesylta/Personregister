namespace Personregister.WebAPI.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> personListe = new List<Person>()
        {
            new Person(){Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 },
            new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }
        };

        public Person add(Person person)
        {
            personListe.Add(person);

            return person;
        }

        public List<Person> getAll()
        {
            return personListe;
        }
    }
}
