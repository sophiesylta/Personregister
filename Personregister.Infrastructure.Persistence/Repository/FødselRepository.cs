using Microsoft.Extensions.Logging;
using Personregister.Application;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{

    public class FødselRepository : IFødselRepository
    {
        private readonly ILogger<FødselRepository> _logger;
        private Personregistercontext personregistercontext;

        public FødselRepository(ILogger<FødselRepository> logger, Personregistercontext Personregistercontext, INavnService navnService)
        {

            personregistercontext = Personregistercontext;
            _logger = logger;
        
            if (personregistercontext.Fødsler.Count() < 3)
            {
                _logger.LogInformation("ingen fødsler opprettet, legger til");
               // add(new Fødsel() { mor = new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 }, far = new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() { Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756 } });

              
                (string fornavnMor, string etternavnMor) = navnService.getNavn(12312312312);
                
                (string fornavnFar, string etternavnFar) = navnService.getNavn(23423423423);


                add(new Fødsel() { mor = new Person() { Fornavn = fornavnMor, Etternavn = etternavnMor, Personnummer = 12312312312 }, far = new Person() { Fornavn = fornavnFar, Etternavn = etternavnFar, Personnummer = 23423423423 }, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() { Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756 } });
                
            }

            else
            {
                _logger.LogInformation("fant fødsler");
            }
        }

        public Fødsel add(Fødsel fødsel)
        {
            personregistercontext.Fødsler.Add(fødsel);
            personregistercontext.SaveChanges();
            return fødsel;
        }

        public List<Fødsel> getAll()
        {
            return personregistercontext.Fødsler.ToList();
        }

        public Person getPerson(long personnummer)
        {
            return personregistercontext.Personer.Where(e => e.Personnummer == personnummer).FirstOrDefault();
        }
    }
}
