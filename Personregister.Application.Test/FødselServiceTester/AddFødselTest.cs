using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Moq;
using Personregister.WebAPI.Models;

namespace Personregister.Application.Test.KallenavnServiceTester
{
    public class AddF�dselTest
    {
        F�dselService f�dselService;
        Mock<IF�dselRepository> f�dselRepository;
        Mock<IPersonRepository> personRepository;

        public AddF�dselTest()
        {
            f�dselRepository = new Mock<IF�dselRepository>();
            personRepository = new Mock<IPersonRepository>();
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();


            f�dselService = new F�dselService(f�dselRepository.Object, navnService, personRepository.Object);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestF�dselService()
        {
            DTOF�dsel f�dselDTO = LagTestF�dsel();
            var f�dsel = f�dselService.add(f�dselDTO);
            //ingen person er registrert fra f�r ...skal da legge til mor,far og barn i person ,  og en f�dsel 
            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(3));
            f�dselRepository.Verify(e=>e.add(It.IsAny<F�dsel>()),Times.Once);

            Assert.NotNull(f�dselDTO);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestMorSkalOpprettesHvisIkkeFinnesFraF�r()
        {
            DTOF�dsel f�dselDTO = LagTestF�dsel();

            var f�dsel = f�dselService.add(f�dselDTO);

            //test mors navn skal v�re utfylt...
            Assert.False(string.IsNullOrEmpty(f�dsel.mor.Fornavn));
            Assert.False(string.IsNullOrEmpty(f�dsel.mor.Etternavn));

            Assert.NotNull(f�dsel);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestFarFinnesFraF�r()
        {
            //Far finnes fra f�r
            const String farsFornavn = "Far";
            const String farsEtternavn = "FarsEtternavn";
            const long farsPersonnummer = 32345678901;

            personRepository.Setup(e => e.getPerson(32345678901)).Returns(new Person() { Personnummer = farsPersonnummer, Fornavn = farsFornavn, Etternavn = farsEtternavn });

            DTOF�dsel f�dselDTO = LagTestF�dsel();
            f�dselDTO.personnummerFar = farsPersonnummer;

            var f�dsel = f�dselService.add(f�dselDTO);

            //test fars navn skal v�re utfylt...
            Assert.Equal(farsFornavn, f�dsel.far.Fornavn);
            Assert.Equal(farsEtternavn, f�dsel.far.Etternavn);


            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(2));
            f�dselRepository.Verify(e => e.add(It.IsAny<F�dsel>()), Times.Once);
        }


        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestBarnFinnesFra()
        {
            //Barns finnes fra f�r
            const String barnsFornavn = "barnsFornavn";
            const String barnsEtternavn = "barnsEtternavn";
            const long barnsPersonnummer = 12345678901;

            personRepository.Setup(e => e.getPerson(12345678901)).Returns(new Person() { Personnummer = 12345678901, Fornavn = barnsFornavn, Etternavn = barnsEtternavn });

            DTOF�dsel f�dselDTO = LagTestF�dsel();
            f�dselDTO.barn.Personnummer = barnsPersonnummer;

            //test barn navn skal v�re utfylt...
            //Assert.Equal(barnsFornavn, f�dsel.barn.Fornavn);
            //Assert.Equal(barnsEtternavn, f�dsel.barn.Etternavn);
            Assert.Throws<Exception>(()=>f�dselService.add(f�dselDTO));

            personRepository.Verify(e => e.add(It.IsAny<Person>()), Times.Exactly(2));
            f�dselRepository.Verify(e => e.add(It.IsAny<F�dsel>()), Times.Never);
        }

        private DTOF�dsel LagTestF�dsel()
        {
            DTOF�dsel f�dselDTO = new DTOF�dsel()
            {
                personnummerMor = 22345678901,
              
                personnummerFar = 32345678901,
                
                barn = new Person()
                {
                    Fornavn = "Ole",
                    Etternavn = "",
                    Personnummer = 12345678901
                },
                f�dselTid = DateTime.Now
            };

            return f�dselDTO;
        }
    }
}