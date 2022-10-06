using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application
{
    public class InitDataService : IInitDataService
    {
        private readonly IDtoPersonService personService;
        List<long> personnummerListe = new List<long>() { 12312312312, 23423423423, 78978978978 };
        List<string> barnePersonnummerListe = new List<string> { "345345", "456456", "567567" };

        List<long> andebyenNummerListe = new List<long> { 11111111111, 22222222222, 33333333333 };
        List<string> andebyenNavneLise = new List<string> { "Ole", "Dole", "Doffen" };
        List<string> andebyenBarnenummer = new List<string> { "444444", "555555", "666666" };

        public InitDataService(IFødselService fødselService, INavnService navnService, IDødsfallService dødsfallService, IDtoPersonService personService)
        {
            //Legge til personer
            foreach (var personnummer in personnummerListe) 
            {
                (string fornavn, string etternavn) = navnService.getNavn(personnummer);
                personService.add(new DTOAddPerson() { fornavn = fornavn, etternavn = etternavn, fodselsnummer = personnummer });
            }

            //Legge til fødsler
            var barnenummer = 1;
            foreach (var personnummer in barnePersonnummerListe) 
            {
                fødselService.add(new DTOFødsel()
                {
                    
                    personnummerMor  = personnummerListe[0],
                    personnummerFar = personnummerListe[1] ,
                    barn = new DTOBarn() { Fornavn = $"barn{barnenummer}", Etternavn = "", Fodselsdato = personnummer, },
                    fødselTid = DateTime.Now.AddYears(-10+barnenummer*2)
                });
                barnenummer++;
            }
            leggTilAndeby(personService, fødselService, navnService);
            registrerDødsfall(dødsfallService, navnService, personService);


            //Legge til dødsfall


        }

        public void leggTilAndeby(IDtoPersonService personService, IFødselService fødselService, INavnService navnService)
        {
            foreach (var personnummer in andebyenNummerListe)
            {
                (string fornavn, string etternavn) = navnService.getNavn(personnummer);
                personService.add(new DTOAddPerson() { fornavn = fornavn, etternavn = etternavn, fodselsnummer = personnummer });
            }

            var i = 0;

            foreach (var personnummer in andebyenBarnenummer)
            {
                fødselService.add(new DTOFødsel
                {
                    personnummerMor = andebyenNummerListe[0],
                    personnummerFar = andebyenNummerListe[1],
                    barn = new DTOBarn() { Fornavn = andebyenNavneLise[i], Etternavn = "", Fodselsdato = personnummer, },
                    fødselTid = DateTime.Now.AddYears(-10 + i * 2)
                });
                i++;
            }
            
        }

        public void registrerDødsfall(IDødsfallService dødsfallService, INavnService navnService, IDtoPersonService personService)
        {
            (string fornavn, string etternavn) = ("Dole", "Duck-Mouse");
            var person1 = personService.add(new DTOAddPerson() {fornavn = fornavn, etternavn = etternavn, fodselsnummer = Int64.Parse(andebyenBarnenummer[2]) });

            dødsfallService.add(new DTODødsfall()
            {
                personnummer = person1.fodselsnummer,
                dodsTid = new DateTime(2022, 12, 24, 7, 0, 0),
                dodsarsak = "Sjelden genetisk sykdom" 
            });

            (fornavn, etternavn) = navnService.getNavn(andebyenNummerListe[1]);
            var person2 = personService.add(new DTOAddPerson() { fornavn = fornavn, etternavn = etternavn, fodselsnummer = andebyenNummerListe[1] });

            dødsfallService.add(new DTODødsfall()
            {
                personnummer = person2.fodselsnummer,
                dodsTid = new DateTime(2022, 12, 27, 13, 10, 22),
                dodsarsak = "Sorg" 
            });
        }
    }
}
