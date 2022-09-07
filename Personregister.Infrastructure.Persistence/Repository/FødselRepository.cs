using Microsoft.Extensions.Logging;
using Personregister.Domene;
using Personregister.Domene.Repository;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{

    public class FødselRepository : IFødselRepository
    {
        private readonly ILogger<FødselRepository> _logger;
        private Personregistercontext personregistercontext;

        public FødselRepository(ILogger<FødselRepository> logger, Personregistercontext Personregistercontext)
        {

            personregistercontext = Personregistercontext;
            _logger = logger;
        
            if (personregistercontext.Fødsler.Count() < 3)
            {
                _logger.LogInformation("ingen fødsler opprettet, legger til");
                add(new Fødsel() { mor = new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 }, far = new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() { Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756 } });
            }
            else
            {
                _logger.LogInformation("fant fødsler");
            }
        }

        public Fødsel add(Fødsel fødsel)
        {
            //sjekk om mor eksisterer, i så fall bruk denne, ellers opprett ny
            var mor = personregistercontext.Personer.Where(e => e.Personnummer == fødsel.mor.Personnummer).FirstOrDefault();
            if (mor != null)
            {
                fødsel.mor = mor;
            }
            //Sjekk om far eksisterer, i så fall bruk denne, ellers opprett ny
            var far = personregistercontext.Personer.Where(e => e.Personnummer == fødsel.far.Personnummer).FirstOrDefault();
            if (far != null)
            {
                fødsel.far = far;
            }

            personregistercontext.Fødsler.Add(fødsel);
            personregistercontext.SaveChanges();
            return fødsel;
        }

        public List<Fødsel> getAll()
        {
            return personregistercontext.Fødsler.ToList();
        }
    }
}
