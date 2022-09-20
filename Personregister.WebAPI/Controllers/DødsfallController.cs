using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class D�dsfallController : ControllerBase
    {
        private readonly ID�dsfallService d�dsfallService;

        public D�dsfallController(ID�dsfallService d�dsfallService)
        {
            this.d�dsfallService = d�dsfallService;
        }

        [HttpGet(Name = "GetD�dsfall")]
        public IEnumerable<DTOGetD�dsfall> Get()
        {
            return d�dsfallService.GetAll();
        }

        [HttpPost(Name = "PostD�dsfall")]
        public D�dsfall Post(DTOD�dsfall d�dsfallDTO)
        {
            return d�dsfallService.add(d�dsfallDTO);
        }
    }
}