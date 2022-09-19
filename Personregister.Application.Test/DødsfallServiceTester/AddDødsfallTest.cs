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

namespace Personregister.Application.Test.DødsfallServiceTester
{
    public class AddDødsfallTest
    {
        DødsfallService dødsfallService;
        Mock<IDødsfallRepository> dødsfallRepository;
        Mock<IPersonRepository> personRepository;
        Mock<ILogger<DødsfallService>> logger;
        

        public AddDødsfallTest()
        {
            dødsfallRepository = new Mock<IDødsfallRepository>();
            personRepository = new Mock<IPersonRepository>();
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();
            logger = new Mock<ILogger<DødsfallService>>();
             


            dødsfallService = new DødsfallService(dødsfallRepository.Object, personRepository.Object, logger.Object);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallService()
        {
            var dødsfall = nyttDødsfall();
            
            personRepository.Setup(e => e.getPerson(dødsfall.person.Personnummer)).Returns(dødsfall.person);

            dødsfall = dødsfallService.add(dødsfall);

            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Once);

            Assert.NotNull(dødsfall);
        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallPersonFinnesIkke() 
        {
            var dødsfall = nyttDødsfall();
            
            // Sjekker at riktig feilmelding blir kastet når personen ikke finnes fra før
            var ex = Assert.Throws<Exception>(()=> dødsfallService.add(dødsfall));

            Assert.Equal($"Finner ikke person med personnummer{dødsfall.person.Personnummer}", ex.Message);

        }

        [Fact]
        [Trait("DødsfallService", "DødsfallService")]
        public void TestDødsfallEksistererFraFør()
        {
            var dødsfall = nyttDødsfall();

            personRepository.Setup(e => e.getPerson(dødsfall.person.Personnummer)).Returns(dødsfall.person);

            dødsfallRepository.Setup(e => e.getDødsfall(dødsfall.person.Personnummer)).Returns(dødsfall);

            dødsfall = dødsfallService.add(dødsfall);

            dødsfallRepository.Verify(e => e.add(It.IsAny<Dødsfall>()), Times.Never);
        }

        public Dødsfall nyttDødsfall() 
        {
            Dødsfall dødsfall = new Dødsfall()
            {
                person = new Person()
                {
                    Personnummer = 12312312312,
                    Fornavn = "Sophie",
                    Etternavn = "Sylta"
                },
                dødsårsak = "ukjent",
                dødsTid = DateTime.Now
            };

            return dødsfall;
        }
    }
}
