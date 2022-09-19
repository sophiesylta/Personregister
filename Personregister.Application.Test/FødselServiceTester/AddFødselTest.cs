using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Moq;
using Personregister.WebAPI.Models;

namespace Personregister.Application.Test.KallenavnServiceTester
{
    public class AddFødselTest
    {
        FødselService fødselService;
        Mock<IFødselRepository> fødselRepository;
        Mock<IPersonRepository> personRepository;

        public AddFødselTest()
        {
            fødselRepository = new Mock<IFødselRepository>();
            personRepository = new Mock<IPersonRepository>();
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();


            fødselService = new FødselService(fødselRepository.Object, navnService, personRepository.Object);
        }

        [Fact]
        [Trait("FødselService", "FødselService")]
        public void TestFødselService()
        {
            DTOFødsel fødselDTO = LagTestFødsel();
            var fødsel = fødselService.add(fødselDTO);
            //ingen person er registrert fra før ...skal da legge til mor,far og barn i person ,  og en fødsel 
            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(3));
            fødselRepository.Verify(e=>e.add(It.IsAny<Fødsel>()),Times.Once);

            Assert.NotNull(fødselDTO);
        }

        [Fact]
        [Trait("FødselService", "FødselService")]
        public void TestMorSkalOpprettesHvisIkkeFinnesFraFør()
        {
            DTOFødsel fødselDTO = LagTestFødsel();

            var fødsel = fødselService.add(fødselDTO);

            //test mors navn skal være utfylt...
            Assert.False(string.IsNullOrEmpty(fødsel.mor.Fornavn));
            Assert.False(string.IsNullOrEmpty(fødsel.mor.Etternavn));

            Assert.NotNull(fødsel);
        }

        [Fact]
        [Trait("FødselService", "FødselService")]
        public void TestFarFinnesFraFør()
        {
            //Far finnes fra før
            const String farsFornavn = "Far";
            const String farsEtternavn = "FarsEtternavn";
            const long farsPersonnummer = 32345678901;

            personRepository.Setup(e => e.getPerson(32345678901)).Returns(new Person() { Personnummer = farsPersonnummer, Fornavn = farsFornavn, Etternavn = farsEtternavn });

            DTOFødsel fødselDTO = LagTestFødsel();
            fødselDTO.personnummerFar = farsPersonnummer;

            var fødsel = fødselService.add(fødselDTO);

            //test fars navn skal være utfylt...
            Assert.Equal(farsFornavn, fødsel.far.Fornavn);
            Assert.Equal(farsEtternavn, fødsel.far.Etternavn);


            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(2));
            fødselRepository.Verify(e => e.add(It.IsAny<Fødsel>()), Times.Once);
        }


        [Fact]
        [Trait("FødselService", "FødselService")]
        public void TestBarnFinnesFra()
        {
            //Barns finnes fra før
            const String barnsFornavn = "barnsFornavn";
            const String barnsEtternavn = "barnsEtternavn";
            const long barnsPersonnummer = 12345678901;

            personRepository.Setup(e => e.getPerson(12345678901)).Returns(new Person() { Personnummer = 12345678901, Fornavn = barnsFornavn, Etternavn = barnsEtternavn });

            DTOFødsel fødselDTO = LagTestFødsel();
            fødselDTO.barn.Personnummer = barnsPersonnummer;

            //test barn navn skal være utfylt...
            //Assert.Equal(barnsFornavn, fødsel.barn.Fornavn);
            //Assert.Equal(barnsEtternavn, fødsel.barn.Etternavn);
            Assert.Throws<Exception>(()=>fødselService.add(fødselDTO));

            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(2));
            fødselRepository.Verify(e => e.add(It.IsAny<Fødsel>()), Times.Never);
        }

        private DTOFødsel LagTestFødsel()
        {
            DTOFødsel fødselDTO = new DTOFødsel()
            {
                personnummerMor = 22345678901,
              
                personnummerFar = 32345678901,
                
                barn = new Person()
                {
                    Fornavn = "Ole",
                    Etternavn = "",
                    Personnummer = 12345678901
                },
                fødselTid = DateTime.Now
            };

            return fødselDTO;
        }
    }
}