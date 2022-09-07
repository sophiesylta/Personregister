using Personregister.Domene;
using Personregister.Domene.Repository;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class DødsfallRepository : IDødsfallRepository
    {
        private readonly Personregistercontext personregistercontext;
        public DødsfallRepository(Personregistercontext personregistercontext) 
        {
            this.personregistercontext = personregistercontext;

            add(new Dødsfall() { person = new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 }, dødsTid = new DateTime(2022, 12, 24, 7, 0, 0), dødsårsak = "Ukjent" });
            add(new Dødsfall() { person = new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }, dødsTid = new DateTime(2022, 12, 27, 13, 10, 22), dødsårsak = "Sorg" });
        }

        public Dødsfall add(Dødsfall dødsfall)
        {
            
            //sjekk om dødsfall eksisterer, i så fall, bruk dette, ellers opprett nytt
            var d = personregistercontext.Dødsfall.FirstOrDefault(x => x.person.Personnummer == dødsfall.person.Personnummer);

            if (d != null) return dødsfall;


            //sjekk om person eksisterer, i så fall bruk denne, ellers opprett ny
            var person = personregistercontext.Personer.Where(e => e.Personnummer == dødsfall.person.Personnummer).FirstOrDefault();

            if (person != null)
            {
                dødsfall.person = person;
            }

            personregistercontext.Dødsfall.Add(dødsfall);
            personregistercontext.SaveChanges();

            return dødsfall;
        }

        public List<Dødsfall> GetAll()
        {
            return personregistercontext.Dødsfall.ToList();
        }
    }
}
