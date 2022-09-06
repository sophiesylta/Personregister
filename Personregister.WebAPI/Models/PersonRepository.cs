namespace Personregister.WebAPI.Models
{
    public class PersonRepository : IPersonRepository
    {
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
        private readonly Personregistercontext personregistercontext;

        public Person add(Person person)
        {

            this.personregistercontext.Personer.Add(person);
            this.personregistercontext.SaveChanges();
            //   personListe.Add(person);

            return person;
        }

        public List<Person> getAll()
        {
            //  return personListe;

            return this.personregistercontext.Personer.ToList();

        }
    }
}
