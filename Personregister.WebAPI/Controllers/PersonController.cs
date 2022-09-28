using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IDtoPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IDtoPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<DTOPerson> Get([FromServices] IDtoGetPersonService dtoGetPersonService)
        {
            return dtoGetPersonService.getAll();
        }

        [HttpPost(Name = "PostPerson")]
        public DTOAddPerson Post(DTOAddPerson personDTO)
        {
            _logger.LogDebug($"Legger til ny person {personDTO.fornavn}");
            personDTO = _personService.add(personDTO);

            return personDTO;
        }

        [HttpPut(Name = "EditPerson")]
        public DTOEditPerson Put(DTOEditPerson person)
        {
            return _personService.edit(person);
        }
    }
}