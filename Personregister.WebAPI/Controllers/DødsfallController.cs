using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DødsfallController : ControllerBase
    {
        private readonly IDødsfallService dødsfallService;

        public DødsfallController(ILogger<DødsfallController> logger, IDødsfallService dødsfallService)
        {
            this.dødsfallService = dødsfallService;
        }

        [HttpGet(Name = "GetDødsfall")]
        public IEnumerable<Dødsfall> Get()
        {
            return dødsfallService.GetAll();
        }

        [HttpPost(Name = "PostDødsfall")]
        public Dødsfall Post(DTODødsfall dødsfallDTO)
        {
            var dødsfall = new Dødsfall()
            {
                person = new Person() { Personnummer = dødsfallDTO.personnummer },
                dødsårsak = dødsfallDTO.dødsårsak,
                dødsTid = dødsfallDTO.dødsTid
            };

            dødsfall = dødsfallService.add(dødsfall);

            return dødsfall;
        }
    }
}