using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class D�dsfallController : ControllerBase
    {
        private readonly ID�dsfallService d�dsfallService;

        public D�dsfallController(ILogger<D�dsfallController> logger, ID�dsfallService d�dsfallService)
        {
            this.d�dsfallService = d�dsfallService;
        }

        [HttpGet(Name = "GetD�dsfall")]
        public IEnumerable<D�dsfall> Get()
        {
            return d�dsfallService.GetAll();
        }

        [HttpPost(Name = "PostD�dsfall")]
        public D�dsfall Post(DTOD�dsfall d�dsfallDTO)
        {
            var d�dsfall = new D�dsfall()
            {
                person = new Person() { Personnummer = d�dsfallDTO.personnummer },
                d�ds�rsak = d�dsfallDTO.d�ds�rsak,
                d�dsTid = d�dsfallDTO.d�dsTid
            };

            d�dsfall = d�dsfallService.add(d�dsfall);

            return d�dsfall;
        }
    }
}