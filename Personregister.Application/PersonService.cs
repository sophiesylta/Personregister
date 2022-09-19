using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
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
        public Person add(Person person)
        {
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            var p = personRepository.getPerson(person.Personnummer);

            if (p != null)
            {
                return p;
            }

            person.Kallenavn = kallenavnService.getKallenavn(person.Fornavn, person.Etternavn);
            personRepository.add(person);
            return person;
        }

        public List<Person> getAll() 
        {
            return personRepository.getAll();

        }
    }
}
