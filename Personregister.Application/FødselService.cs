using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;
using System.Reflection.Metadata;

namespace Personregister.Application
{
    public class FødselService : IFødselService
    {
        private readonly IFødselRepository fødselRepository;
        private readonly INavnService navnService;
        private readonly IPersonService personService;

        public FødselService(IFødselRepository fødselRepository, INavnService navnService, IPersonService personService)
        {
            this.fødselRepository = fødselRepository;
            this.navnService = navnService;
            this.personService = personService;
        }

        public DTOFødsel add(DTOFødsel fødselDTO)
        {
            //sjekk om mor eksisterer, i så fall bruk denne, ellers opprett ny
            var mor = personService.getPerson(fødselDTO.personnummerMor);

            if (mor != null)
            {

                fødselDTO.personnummerMor = mor.Personnummer;
            }
            else
            {
                (mor.Fornavn, mor.Etternavn) = navnService.getNavn(fødselDTO.personnummerMor);
                personService.add(new DTOAddPerson() { fornavn =  mor.Fornavn, etternavn = mor.Etternavn, personnummer = fødselDTO.personnummerMor});
            }

            //Sjekk om far eksisterer, i så fall bruk denne, ellers opprett ny
            var far = personService.getPerson(fødselDTO.personnummerFar);

            if (far != null)
            {
                fødselDTO.personnummerFar = far.Personnummer;
            }
            else 
            {
                (far.Fornavn, far.Etternavn) = navnService.getNavn(fødselDTO.personnummerFar);
                personService.add(new DTOAddPerson() { fornavn = far.Fornavn, etternavn = far.Etternavn, personnummer = fødselDTO.personnummerFar });
            }

            //Sjekk om barn eksisterer, i så fall kast exception

            var barn = personService.getPerson(fødselDTO.barn.Personnummer);
         
            if (barn != null)
            {
                throw new Exception($"Barn finnes med personnummer {fødselDTO.barn.Personnummer} fra før ");
            }

            if (fødselDTO.barn.Etternavn == "") fødselDTO.barn.Etternavn = $"{mor.Etternavn}-{far.Etternavn}";



            personService.add(new DTOAddPerson() { fornavn = fødselDTO.barn.Fornavn, etternavn = fødselDTO.barn.Etternavn, personnummer = fødselDTO.barn.Personnummer });
            

            fødselRepository.add(
                new Fødsel() 
                { 
                    mor = mor, 
                    far = far, 
                    barn = personService.getPerson(fødselDTO.barn.Personnummer)
                });
            return fødselDTO;
        }

        public List<DTOGetFødsel> getAll()
        {
            var fødselDTOList = new List<DTOGetFødsel>();

            var fødselList = fødselRepository.getAll();

            foreach (var fødsel in fødselList)
            {
                
                fødselDTOList.Add(fødselTilDTO(fødsel));
            }
            return fødselDTOList;
        }


        //Gjør Fødsel om til DTOGetFødsel
        private DTOGetFødsel fødselTilDTO (Fødsel fødsel) 
        {
            var f = new DTOGetFødsel()
            {
                mor = new DTOPerson()
                {
                    navn = fødsel.mor.Fornavn + " " + fødsel.mor.Etternavn,
                    kallenavn = fødsel.mor.Kallenavn
                },
                far = new DTOPerson()
                {
                    navn = fødsel.far.Fornavn + " " + fødsel.far.Etternavn,
                    kallenavn = fødsel.far.Kallenavn
                },
                barn = new DTOPerson()
                {
                    navn = fødsel.barn.Fornavn + " " + fødsel.barn.Etternavn,
                    kallenavn = fødsel.barn.Kallenavn
                }
            };

            return f;

        }
    }
}

