using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application
{
    public class PersonService : IPersonService, IDtoPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IKallenavnService kallenavnService;

        public PersonService(IPersonRepository personRepository, IKallenavnService kallenavnService)
        {
            this.personRepository = personRepository;
            this.kallenavnService = kallenavnService;
        }
        public DTOAddPerson add(DTOAddPerson personDTO)
        {

            Person person =add(new Person() {Personnummer = personDTO.personnummer, Etternavn = personDTO.etternavn, Fornavn = personDTO.fornavn });
            personDTO = new DTOAddPerson() { etternavn = person.Etternavn, fornavn = person.Fornavn, personnummer = person.Personnummer };
            return personDTO;
        }

        public Person add(Person person)
        {
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            if (personRepository.getPerson(person.Personnummer) != null)
            {
                return person;
            }

            person.Kallenavn = kallenavnService.getKallenavn(person.Fornavn, person.Etternavn);
            personRepository.add(person);
            return person;
        }




        public List<DTOPerson> getAll() 
        {
            return personRepository.getAll().Select(e => new DTOPerson() { navn = e.Fornavn + " " + e.Etternavn, kallenavn = e.Kallenavn }).ToList();

        }

        public Person getPerson(long personnummer)
        {
            return personRepository.getPerson(personnummer);
        }

        public DTOEditPerson edit(DTOEditPerson person)
        {
            if (person.fornavn == "" || person.fornavn == null) person.fornavn = "Ukjent";
            if (person.etternavn == "" || person.etternavn == null) person.etternavn = "Ukjent";

            var p = personRepository.getPerson(person.personnummer);
            p.Fornavn = person.fornavn;
            p.Etternavn = person.etternavn;

            p.Kallenavn = kallenavnService.getUniktKallenavn(person.kallenavn);
            p = personRepository.edit(p);
            return new DTOEditPerson() { personnummer = p.Personnummer, fornavn = p.Fornavn, etternavn = p.Etternavn, kallenavn = p.Kallenavn };
        }
    }
}
