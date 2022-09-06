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
