using Microsoft.Extensions.Logging;
using Optional;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application
{
    public class DødsfallService : IDødsfallService
    {
        private readonly IDødsfallRepository dødsfallRepository;
        private readonly IPersonService personService;
        private readonly ILogger<DødsfallService> logger;

        public DødsfallService(IDødsfallRepository dødsfallRepository, IPersonService personService, ILogger<DødsfallService> logger)
        {
            this.dødsfallRepository = dødsfallRepository;

            this.personService = personService;
            this.logger = logger;
        }

        public Dødsfall add(DTODødsfall dødsfallDTO)
        {
            Person person;

            //Sjekk om DTO har verdi for personnummer, i så fall sjekk om person eksisterer
            if (dødsfallDTO.personnummer != 0)
            {
                person = personService.getPerson(dødsfallDTO.personnummer);
            }
            //Bruker DTO sin verdi for kallenavn for å sjekke om person eksisterer
            else
            {
                person = personService.getPersonByKallenavn(dødsfallDTO.kallenavn);
            }

            //Hvis person ikke eksisterer, kast exception
            if (person == null)
            {
                logger.LogError("Finner ikke person ");
                throw new Exception("Finner ikke person");
            }

            //Oppretter dødsfall fra DTO
            var dødsfall = new Dødsfall
            {
                person = person,
                dødsårsak = dødsfallDTO.dodsarsak,
                dødsTid = dødsfallDTO.dodsTid
            };

            //sjekk om dødsfall eksisterer, i så fall, returneres dette, ellers opprett nytt
            Option<Dødsfall> d = dødsfallRepository.getDødsfall(Int64.Parse(dødsfall.person._Fødselsnummer));
            Dødsfall registrertDødsfall = d.Match(
                df =>
                {
                    logger.LogError("Dødsfall allerede registrert");
                    return df;
                },
                () => dødsfallRepository.add(dødsfall)
            );
            return registrertDødsfall;
        }

        public List<DTOGetDødsfall> GetAll()
        {
            var dødsfallDTOListe = new List<DTOGetDødsfall>();
            var dødsfallListe = dødsfallRepository.GetAll();
            foreach (var d in dødsfallListe)
            {
                var dto = new DTOGetDødsfall() { fornavn = d.person.Fornavn, etternavn = d.person.Etternavn, dodsarsak = d.dødsårsak };
                dødsfallDTOListe.Add(dto);
            }
            return dødsfallDTOListe;
        }
    }   
}
