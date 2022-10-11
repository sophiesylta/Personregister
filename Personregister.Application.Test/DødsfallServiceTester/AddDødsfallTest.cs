using Moq;
using Personregister.Application.Contracts.Repository;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Microsoft.Extensions.Logging;
using Personregister.DTO;

namespace Personregister.Application.Test.DødsfallServiceTester
{
    public class AddDødsfallTest
    {
        IDødsfallService dødsfallService;
        Mock<IDødsfallRepository> dødsfallRepository;
        Mock<IPersonService> personService;
        Mock<ILogger<DødsfallService>> logger;
        

        public AddDødsfallTest()
        {
            dødsfallRepository = new Mock<IDødsfallRepository>(MockBehavior.Strict);
            personService = new Mock<IPersonService>(MockBehavior.Strict);
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();
            logger = new Mock<ILogger<DødsfallService>>();
             


            dødsfallService = new DødsfallService(dødsfallRepository.Object, personService.Object, logger.Object);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallService()
        {
            var person = nyPerson();
            var dødsfallDto = nyDødsfallDTO();

            var lagretDødsfall = new Dødsfall
            {
                DødsfallId = 99,
                dødsTid = dødsfallDto.dodsTid,
                dødsårsak = dødsfallDto.dodsarsak,
                person = person
            };

            personService.Setup(e => e.getPerson(Int64.Parse(person._Fødselsnummer))).Returns(person);
            dødsfallRepository.Setup(e => e.getDødsfall(Int64.Parse(person._Fødselsnummer))).Returns(value: null);
            dødsfallRepository.Setup(e => e.add(It.IsAny<Dødsfall>())).Returns(lagretDødsfall);

            var addedDødsfall = dødsfallService.add(dødsfallDto);

            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Once);
            Assert.Equal(lagretDødsfall, addedDødsfall);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallPersonFinnesIkke() 
        {
            var dødsfallDTO = nyDødsfallDTO();

            personService.Setup(e => e.getPerson(dødsfallDTO.personnummer)).Returns(value: null);

            // Sjekker at riktig feilmelding blir kastet når personen ikke finnes fra før
            var ex = Assert.Throws<Exception>(()=> dødsfallService.add(dødsfallDTO));

            Assert.Equal("Finner ikke person", ex.Message);

        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallEksistererFraFør()
        {
            var eksisterendeDødsfall = nyttDødsfall();
            var dødsfallDTO = new DTODødsfall
            {
                personnummer = Int64.Parse(eksisterendeDødsfall.person._Fødselsnummer),
                dodsarsak = "velkjent i morgen",
                dodsTid = eksisterendeDødsfall.dødsTid.AddDays(1)
            };

            personService.Setup(e => e.getPerson(dødsfallDTO.personnummer)).Returns(eksisterendeDødsfall.person);

            dødsfallRepository.Setup(e => e.getDødsfall(dødsfallDTO.personnummer)).Returns(eksisterendeDødsfall);

            Dødsfall addedDødsfall = dødsfallService.add(dødsfallDTO);

            // Verifiser at IDødsfallRepository.add() ikke har blitt kalt
            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Never);
            // Verifiser at det returnerte dødsfallet er det eksisterende, ikke det nye
            Assert.Equal(eksisterendeDødsfall, addedDødsfall);
        }

        private Dødsfall nyttDødsfall() 
        {
            return new Dødsfall
            {
                person = nyPerson(),
                dødsårsak = "ukjent",
                dødsTid = DateTime.Now
            };
        }

        private DTODødsfall nyDødsfallDTO() 
        {
            return new DTODødsfall
            {
                personnummer = Int64.Parse(nyPerson()._Fødselsnummer),
                dodsarsak = nyttDødsfall().dødsårsak,
                dodsTid = nyttDødsfall().dødsTid
            };
        }

        private Person nyPerson()
        {
            return new Person(12312312312)
            {
                Fornavn = "Sophie",
                Etternavn = "Sylta"
            };
        }
    }
}
