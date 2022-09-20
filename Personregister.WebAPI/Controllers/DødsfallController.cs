using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DødsfallController : ControllerBase
    {
        private readonly IDødsfallService dødsfallService;

        public DødsfallController(IDødsfallService dødsfallService)
        {
            this.dødsfallService = dødsfallService;
        }

        [HttpGet(Name = "GetDødsfall")]
        public IEnumerable<DTOGetDødsfall> Get()
        {
            return dødsfallService.GetAll();
        }

        [HttpPost(Name = "PostDødsfall")]
        public Dødsfall Post(DTODødsfall dødsfallDTO)
        {
            return dødsfallService.add(dødsfallDTO);
        }
    }
}