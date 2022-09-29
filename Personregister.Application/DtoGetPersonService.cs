using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application
{
    public class DtoGetPersonService : IDtoGetPersonService
    {
        private readonly IDødsfallRepository dødsfallRepository;
        private readonly IPersonRepository personRepository;
        public DtoGetPersonService(IDødsfallRepository dødsfallRepository, IPersonRepository personRepository)
        {
            this.dødsfallRepository = dødsfallRepository;
            this.personRepository = personRepository;
        }

        public List<DTOPerson> getAll()
        {
            List<DTOPerson> dtoPersoner = new();
            
            var dødePersoner = dødsfallRepository.GetAll().Select(e => e.person);

            var personer = personRepository.getAll();
            foreach (var person in personer)
            {
                var dtoPerson = new DTOPerson() { navn = person.Fornavn + " " + person.Etternavn, kallenavn = person.Kallenavn };
                dtoPerson.erDod = dødePersoner.Any(p => p.erSamme(person));

                dtoPersoner.Add(dtoPerson);
            }

            return dtoPersoner;
        }
    }
}
