using Microsoft.AspNetCore.Mvc;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> personListe = new List<Person>()
        {
            new Person(){Fornavn = "Sophie", Etternavn = "Sylta" },
            new Person() { Fornavn = "Trond", Etternavn = "Århus" }
        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<Person> Get()
        {
            return personListe;
        }

        [HttpPost(Name = "PostPerson")]
        public IEnumerable<Person> Post(Person person)
        {
            personListe.Add(person);

            return personListe;
        }
    }
}