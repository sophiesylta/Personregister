using Personregister.WebAPI.Controllers;

namespace Personregister.WebAPI.Models
{
    public class FødselRepository : IFødselRepository
    {
        private readonly ILogger<FødselRepository> _logger;
        private Personregistercontext personregistercontext;

        public FødselRepository(ILogger<FødselRepository> logger, Personregistercontext Personregistercontext)
        {
            
            this.personregistercontext = Personregistercontext;
            this._logger = logger;

            if (personregistercontext.Fødsler.Count() == 0)
            {
                _logger.LogInformation("ingen fødsler opprettet, legger til");
                personregistercontext.Fødsler.Add(new Fødsel() { mor = new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 }, far = new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() { Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756 } });
                personregistercontext.SaveChanges();
            }
            else {
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
    }
}
