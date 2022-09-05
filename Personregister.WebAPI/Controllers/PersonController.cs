using Microsoft.AspNetCore.Mvc;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> personListe = new List<Person>()
        {
            new Person(){Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 },
            new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 23423423423 }
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