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
        private readonly IDødsfallService dødsfallService;
        private readonly IPersonRepository personRepository;
        public DtoGetPersonService(IDødsfallService dødsfallService, IPersonRepository personRepository)
        {
            this.dødsfallService = dødsfallService;
            this.personRepository = personRepository;
        }

        public List<DTOPerson> getAll()
        {
            
            var dødsfall = dødsfallService.GetAll();
            var personer = personRepository.getAll().Select(e => new DTOPerson() { navn = e.Fornavn + " " + e.Etternavn, kallenavn = e.Kallenavn }).ToList();

            foreach (var d in dødsfall)
            {
                var navn = d.fornavn + " " + d.etternavn;
                var dødPerson = personer.Where(p => p.navn.Equals(navn)).FirstOrDefault();
                dødPerson.erDod = true;
            }

            return personer;
        }
    }
}
