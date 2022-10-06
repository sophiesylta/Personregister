using Moq;
using Personregister.Application.Contracts.Repository;
using Personregister.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personregister.Domene;
using Microsoft.Extensions.Logging;
using Personregister.DTO;

namespace Personregister.Application.Test.DødsfallServiceTester
{
    public class AddDødsfallTest
    {
        DødsfallService dødsfallService;
        Mock<IDødsfallRepository> dødsfallRepository;
        Mock<IPersonService> personService;
        Mock<ILogger<DødsfallService>> logger;
        

        public AddDødsfallTest()
        {
            dødsfallRepository = new Mock<IDødsfallRepository>();
            personService = new Mock<IPersonService>();
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();
            logger = new Mock<ILogger<DødsfallService>>();
             


            dødsfallService = new DødsfallService(dødsfallRepository.Object, personService.Object, logger.Object);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallService()
        {
            var dødsfall = nyttDødsfall();
            var dødsfallDTO = nyDødsfallDTO();

            personService.Setup(e => e.getPerson(Int64.Parse(dødsfall.person._Fødselsnummer))).Returns(dødsfall.person);

            dødsfall = dødsfallService.add(dødsfallDTO);

            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Once);

            Assert.NotNull(dødsfall);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallPersonFinnesIkke() 
        {
            var dødsfallDTO = nyDødsfallDTO();
            
            // Sjekker at riktig feilmelding blir kastet når personen ikke finnes fra før
            var ex = Assert.Throws<Exception>(()=> dødsfallService.add(dødsfallDTO));

            Assert.Equal("Finner ikke person", ex.Message);

        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallEksistererFraFør()
        {
            var dødsfall = nyttDødsfall();
            var dødsfallDTO = nyDødsfallDTO();

            personService.Setup(e => e.getPerson(Int64.Parse(dødsfall.person._Fødselsnummer))).Returns(dødsfall.person);

            dødsfallRepository.Setup(e => e.getDødsfall(Int64.Parse(dødsfall.person._Fødselsnummer))).Returns(dødsfall);

            dødsfall = dødsfallService.add(dødsfallDTO);

            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Never);
        }

        public Dødsfall nyttDødsfall() 
        {
            Dødsfall dødsfall = new Dødsfall()
            {
                person = new Person(12312312312)
                {
                    Fornavn = "Sophie",
                    Etternavn = "Sylta"
                },
                dødsårsak = "ukjent",
                dødsTid = DateTime.Now
            };

            return dødsfall;
        }

        public DTODødsfall nyDødsfallDTO() 
        {
           DTODødsfall dødsfallDTO = new DTODødsfall()
            {
                personnummer = Int64.Parse(nyttDødsfall().person._Fødselsnummer),
                dodsarsak = nyttDødsfall().dødsårsak,
                dodsTid = nyttDødsfall().dødsTid
            };

            return dødsfallDTO;
        }
    }
}
