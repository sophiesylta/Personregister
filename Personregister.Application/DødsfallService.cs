using Microsoft.Extensions.Logging;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;

namespace Personregister.Application
{
    public class DødsfallService : IDødsfallService
    {
        private readonly IDødsfallRepository dødsfallRepository;
        private readonly IPersonRepository personRepository;
        private readonly ILogger<DødsfallService> logger;

        public DødsfallService(IDødsfallRepository dødsfallRepository, IPersonRepository personRepository, ILogger<DødsfallService> logger)
        {
            this.dødsfallRepository = dødsfallRepository;

            this.personRepository = personRepository;
            this.logger = logger;
        }

        public Dødsfall add(Dødsfall dødsfall)
        {
            //sjekk om person eksisterer, i så fall bruk denne, ellers throw exception
            var person = personRepository.getPerson(dødsfall.person.Personnummer);

            if (person == null)
            {
                logger.LogError($"Finner ikke person med personnummer{dødsfall.person.Personnummer}");
                throw new Exception($"Finner ikke person med personnummer{dødsfall.person.Personnummer}");
            }
            dødsfall.person = person;

            //sjekk om dødsfall eksisterer, i så fall, returneres dette, ellers opprett nytt
            var d = dødsfallRepository.getDødsfall(dødsfall.person.Personnummer);

            if (d != null) 
            {
                logger.LogError("Dødsfall allerede registrert");
                return dødsfall;
            }

            dødsfallRepository.add(dødsfall);
            return dødsfall;
          
        }

        public List<Dødsfall> GetAll()
        {
            return dødsfallRepository.GetAll();
        }
    }   
}
