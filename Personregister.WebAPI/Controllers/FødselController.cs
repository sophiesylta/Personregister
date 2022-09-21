using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.DTO;



namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class F�dselController : ControllerBase
    {
        private readonly IF�dselService f�dselService;


        public F�dselController(IF�dselService f�dselService)
        {

            this.f�dselService = f�dselService;

        }

        [HttpGet(Name = "GetF�dsel")]
        public IEnumerable<DTOGetF�dsel> Get()
        {
            return f�dselService.getAll();
        }

        [HttpPost(Name = "PostF�dsel")]
        public Boolean Post(DTOF�dsel f�dselDTO)
        {
           return f�dselService.add(f�dselDTO);

        }
    }
}