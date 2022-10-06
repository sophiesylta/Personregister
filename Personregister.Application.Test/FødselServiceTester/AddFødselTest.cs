using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Moq;
using Personregister.DTO;

namespace Personregister.Application.Test.F�dselServiceTester
{
    public class AddF�dselTest
    {
        F�dselService f�dselService;
        Mock<IF�dselRepository> f�dselRepository;
        Mock<IPersonService> personService;

        public AddF�dselTest()
        {
            f�dselRepository = new Mock<IF�dselRepository>();
            personService = new Mock<IPersonService>();
            //trenger ikke mocke navnService , da den ikke har avhenigheter...
            INavnService navnService = new NavnService();


            f�dselService = new F�dselService(f�dselRepository.Object, personService.Object);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestF�dselService()
        {
            DTOF�dsel f�dselDTO = LagTestF�dsel();
            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerFar)).Returns(() => new Person(f�dselDTO.personnummerFar) { Etternavn = "Etternavn" });
            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerMor)).Returns(() => new Person(f�dselDTO.personnummerMor) { Etternavn = "Etternavn" });

            var f�dsel = f�dselService.add(f�dselDTO);



            //ingen person er registrert fra f�r ...skal da legge til mor,far og barn i person ,  og en f�dsel 
            personService.Verify(e => e.findOrCreate(It.IsAny<long>()), Times.Exactly(2));
            personService.Verify(e => e.add(It.IsAny<Person>()), Times.Once);

            f�dselRepository.Verify(e => e.add(It.IsAny<F�dsel>()), Times.Once);

            Assert.NotNull(f�dselDTO);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestMorSkalOpprettesHvisIkkeFinnesFraF�r()
        {
            DTOF�dsel f�dselDTO = LagTestF�dsel();
            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerFar)).Returns(() => new Person(f�dselDTO.personnummerFar));
            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerMor)).Returns(() => new Person(f�dselDTO.personnummerMor));


            var f�dsel = f�dselService.add(f�dselDTO);

            //test mors navn skal v�re utfylt...
            //Assert.False(string.IsNullOrEmpty(f�dsel.mor.Fornavn));
            //Assert.False(string.IsNullOrEmpty(f�dsel.mor.Etternavn));

            Assert.NotNull(f�dsel);
        }

        [Fact]
        [Trait("F�dselService", "F�dselService")]
        public void TestFarFinnesFraF�r()
        {
            //Far finnes fra f�r
            const string farsFornavn = "Far";
            const string farsEtternavn = "FarsEtternavn";
            const long farsPersonnummer = 32345678901;


            DTOF�dsel f�dselDTO = LagTestF�dsel();

            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerFar)).Returns(() => new Person(f�dselDTO.personnummerFar) { Fornavn = farsFornavn, Etternavn = farsEtternavn });
            personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerMor)).Returns(() => new Person(f�dselDTO.personnummerMor));



            f�dselDTO.personnummerFar = farsPersonnummer;

            var f�dsel = f�dselService.add(f�dselDTO);

            //test fars navn skal v�re utfylt...
            //Assert.Equal(farsFornavn, f�dsel.far.Fornavn);
            //Assert.Equal(farsEtternavn, f�dsel.far.Etternavn);


            personService.Verify(e => e.findOrCreate(It.IsAny<long>()), Times.Exactly(2));
            f�dselRepository.Verify(e => e.add(It.IsAny<F�dsel>()), Times.Once);
        }


        //[Fact]
        //[Trait("F�dselService", "F�dselService")]
        //public void TestBarnFinnesFra()
        //{
        //    //Barns finnes fra f�r
        //    const string barnsFornavn = "barnsFornavn";
        //    const string barnsEtternavn = "barnsEtternavn";
        //    const long barnsPersonnummer = 12345678901;

        //    DTOF�dsel f�dselDTO = LagTestF�dsel();

        //    personService.Setup(e => e.getPerson(12345678901)).Returns(() => new Person(12345678901) { Fornavn = barnsFornavn, Etternavn = barnsEtternavn });
        //    personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerFar)).Returns(() => new Person(f�dselDTO.personnummerFar));
        //    personService.Setup(e => e.findOrCreate(f�dselDTO.personnummerMor)).Returns(() => new Person(f�dselDTO.personnummerMor));



        //    f�dselDTO.barn.Fodselsdato = barnsPersonnummer.ToString();

        //    //test barn navn skal v�re utfylt...
        //    //Assert.Equal(barnsFornavn, f�dsel.barn.Fornavn);
        //    //Assert.Equal(barnsEtternavn, f�dsel.barn.Etternavn);
        //    Assert.Throws<Exception>(() => f�dselService.add(f�dselDTO));

        //    personService.Verify(e => e.findOrCreate(It.IsAny<long>()), Times.Exactly(2));
        //    personService.Verify(e => e.getPerson(It.IsAny<long>()), Times.Exactly(1));

        //    f�dselRepository.Verify(e => e.add(It.IsAny<F�dsel>()), Times.Never);
        //}

        private DTOF�dsel LagTestF�dsel()
        {
            DTOF�dsel f�dselDTO = new DTOF�dsel()
            {
                personnummerMor = 22345678901,

                personnummerFar = 32345678901,

                barn = new DTOBarn()
                {
                    Fornavn = "Ole",
                    Etternavn = "",
                    Fodselsdato = "090621"
                },
                f�dselTid = DateTime.Now
            };

            return f�dselDTO;
        }
    }
}