using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<DTOPerson> Get()
        {
            var personliste = _personService.getAll();
            return personliste.Select(e => new DTOPerson() { navn = e.Fornavn + " " + e.Etternavn, kallenavn = e.Kallenavn });
            //return _personRepository.getAll();
        }

        [HttpPost(Name = "PostPerson")]
        public Person Post(Person person)
        {
            _logger.LogDebug($"Legger til ny person {person.Fornavn}");
            person = _personService.add(person);

            return person;
        }
    }
}