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
        private readonly IPersonService personService;
        List<long> personnummerListe = new List<long>() { 12312312312, 23423423423, 78978978978 };
        List<long> barnePersonnummerListe = new List<long> { 34534534534, 45645645645, 56756756756 };

        List<long> andebyenNummerListe = new List<long> { 11111111111, 22222222222, 33333333333 };
        List<string> andebyenNavneLise = new List<string> { "Ole", "Dole", "Doffen" };
        List<long> andebyenBarnenummer = new List<long> { 44444444444, 55555555555, 66666666666 };

        public InitDataService(IFødselService fødselService, INavnService navnService, IDødsfallService dødsfallService, IPersonService personService)
        {
            //Legge til personer
            foreach (var personnummer in personnummerListe) 
            {
                (string fornavn, string etternavn) = navnService.getNavn(personnummer);
                personService.add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = personnummer });
            }

            //Legge til fødsler
            var barnenummer = 1;
            foreach (var personnummer in barnePersonnummerListe) 
            {
                fødselService.add(new DTOFødsel()
                {
                    
                    personnummerMor  = personnummerListe[0],
                    personnummerFar = personnummerListe[1] ,
                    barn = new Person() { Fornavn = $"barn{barnenummer}", Etternavn = $"barn{barnenummer}", Personnummer = personnummer, },
                    fødselTid = DateTime.Now.AddYears(-10+barnenummer*2)
                });
                barnenummer++;
            }
            leggTilAndeby(personService, fødselService, navnService);
            registrerDødsfall(dødsfallService, navnService, personService);


            //Legge til dødsfall


        }

        public void leggTilAndeby(IPersonService personService, IFødselService fødselService, INavnService navnService)
        {
            foreach (var personnummer in andebyenNummerListe)
            {
                (string fornavn, string etternavn) = navnService.getNavn(personnummer);
                personService.add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = personnummer });
            }

            var i = 0;

            foreach (var personnummer in andebyenBarnenummer)
            {
                fødselService.add(new DTOFødsel
                {
                    personnummerMor = andebyenNummerListe[0],
                    personnummerFar = andebyenNummerListe[1],
                    barn = new Person() { Fornavn = andebyenNavneLise[i], Etternavn = $"barn{i+1}", Personnummer = personnummer, },
                    fødselTid = DateTime.Now.AddYears(-10 + i * 2)
                });
                i++;
            }
            
        }

        public void registrerDødsfall(IDødsfallService dødsfallService, INavnService navnService, IPersonService personService)
        {
            (string fornavn, string etternavn) = navnService.getNavn(andebyenBarnenummer[2]);
            var person1 = personService.add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = andebyenBarnenummer[2] });

            dødsfallService.add(new DTODødsfall()
            {
                personnummer = person1.Personnummer,
                dødsTid = new DateTime(2022, 12, 24, 7, 0, 0),
                dødsårsak = "Sjelden genetisk sykdom" 
            });

            (fornavn, etternavn) = navnService.getNavn(andebyenNummerListe[1]);
            var person2 = personService.add(new Person() { Fornavn = fornavn, Etternavn = etternavn, Personnummer = andebyenNummerListe[1] });

            dødsfallService.add(new DTODødsfall()
            {
                personnummer = person2.Personnummer,
                dødsTid = new DateTime(2022, 12, 27, 13, 10, 22),
                dødsårsak = "Sorg" 
            });
        }
    }
}
