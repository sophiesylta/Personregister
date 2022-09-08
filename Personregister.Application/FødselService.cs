using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using System.Reflection.Metadata;

namespace Personregister.Application
{
    public class FødselService : IFødselService
    {
        private readonly IFødselRepository fødselRepository;
        private readonly INavnService navnService;

        public FødselService(IFødselRepository fødselRepository, INavnService navnService)
        {
            this.fødselRepository = fødselRepository;
            this.navnService = navnService;
        }

        public Fødsel add(Fødsel fødsel)
        {
            //sjekk om mor eksisterer, i så fall bruk denne, ellers opprett ny
            var mor = fødselRepository.getPerson(fødsel.mor.Personnummer);

            if (mor != null)
            {
               
                fødsel.mor = mor;
            }
            else 
            {
                (fødsel.mor.Fornavn, fødsel.mor.Etternavn) = navnService.getNavn(fødsel.mor.Personnummer);
            }

            //Sjekk om far eksisterer, i så fall bruk denne, ellers opprett ny
            var far = fødselRepository.getPerson(fødsel.far.Personnummer);

            if (far != null)
            {
                fødsel.far = far;
            }
            else 
            {
                (fødsel.far.Fornavn, fødsel.far.Etternavn) = navnService.getNavn(fødsel.far.Personnummer);
            }

            fødselRepository.add(fødsel);
            return fødsel;
        }

    }
}

