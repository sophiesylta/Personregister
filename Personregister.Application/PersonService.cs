﻿using Personregister.Application.Contracts;
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
    public class PersonService : IPersonService
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
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            var p = personRepository.getPerson(personDTO.personnummer);

            if (p != null)
            {
                return personDTO;
            }

            Person person = new Person() {Personnummer = personDTO.personnummer, Etternavn = personDTO.etternavn, Fornavn = personDTO.fornavn };

            person.Kallenavn = kallenavnService.getKallenavn(person.Fornavn, person.Etternavn);
            personRepository.add(person);
            return personDTO;
        }

        public List<DTOPerson> getAll() 
        {
            return personRepository.getAll().Select(e => new DTOPerson() { navn = e.Fornavn + " " + e.Etternavn, kallenavn = e.Kallenavn }).ToList();

        }
    }
}
