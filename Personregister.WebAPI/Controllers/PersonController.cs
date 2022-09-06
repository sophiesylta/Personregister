using Microsoft.AspNetCore.Mvc;
using Personregister.Domene;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<Person> Get()
        {
            return _personRepository.getAll();
        }

        [HttpPost(Name = "PostPerson")]
        public Person Post(Person person)
        {
            _logger.LogDebug($"Legger til ny person {person.Fornavn}");
            person = _personRepository.add(person);

            return person;
        }
    }
}