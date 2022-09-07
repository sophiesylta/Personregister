using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;

namespace Personregister.Application
{
    public class FødselService : IFødselService
    {
        private readonly IFødselRepository fødselRepository;

        public FødselService(IFødselRepository fødselRepository)
        {
            this.fødselRepository = fødselRepository;
        }

        public Fødsel add(Fødsel fødsel)
        {
            //sjekk om mor eksisterer, i så fall bruk denne, ellers opprett ny
            var mor = fødselRepository.getPerson(fødsel.mor.Personnummer);

            if (mor != null)
            {
                fødsel.mor = mor;
            }
            //Sjekk om far eksisterer, i så fall bruk denne, ellers opprett ny
            var far = fødselRepository.getPerson(fødsel.far.Personnummer);

            if (far != null)
            {
                fødsel.far = far;
            }

            fødselRepository.add(fødsel);
            return fødsel;
        }

    }
}

