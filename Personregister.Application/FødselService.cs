using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;
using System.Reflection.Metadata;

namespace Personregister.Application
{
    public class FødselService : IFødselService
    {
        private readonly IFødselRepository fødselRepository;
        private readonly INavnService navnService;
        private readonly IPersonRepository personRepository;

        public FødselService(IFødselRepository fødselRepository, INavnService navnService, IPersonRepository personRepository)
        {
            this.fødselRepository = fødselRepository;
            this.navnService = navnService;
            this.personRepository = personRepository;
        }

        public Fødsel add(DTOFødsel fødselDTO)
        {
            // Oppretter fødsel fra DTO
            var fødsel = new Fødsel()
            {
                mor = new Person() { Personnummer = fødselDTO.personnummerMor },
                far = new Person() { Personnummer = fødselDTO.personnummerFar },
                barn = fødselDTO.barn,
                fødselTid = fødselDTO.fødselTid

            };

            //sjekk om mor eksisterer, i så fall bruk denne, ellers opprett ny
            var mor = personRepository.getPerson(fødsel.mor.Personnummer);

            if (mor != null)
            {
               
                fødsel.mor = mor;
            }
            else 
            {
                (fødsel.mor.Fornavn, fødsel.mor.Etternavn) = navnService.getNavn(fødsel.mor.Personnummer);
                personRepository.add(fødsel.mor);
            }

            //Sjekk om far eksisterer, i så fall bruk denne, ellers opprett ny
            var far = personRepository.getPerson(fødsel.far.Personnummer);

            if (far != null)
            {
                fødsel.far = far;
            }
            else 
            {
                (fødsel.far.Fornavn, fødsel.far.Etternavn) = navnService.getNavn(fødsel.far.Personnummer);
                personRepository.add(fødsel.far);
            }

            fødsel.barn.Etternavn = $"{fødsel.mor.Etternavn}-{fødsel.far.Etternavn}";

            //Sjekk om barn eksisterer, i så fall returner fødsel

            var barn = personRepository.getPerson(fødsel.barn.Personnummer);
         
            if (barn != null)
            {
                throw new Exception($"Barn finnes med personnummer {fødsel.barn.Personnummer} fra før ");
            }

            personRepository.add(fødsel.barn);

            fødselRepository.add(fødsel);
            return fødsel;
        }

        public List<Fødsel> getAll()
        {
            return fødselRepository.getAll();
        }
    }
}

