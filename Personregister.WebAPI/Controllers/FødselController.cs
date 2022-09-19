using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Domene;
using Personregister.DTO;



namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FødselController : ControllerBase
    {
        private readonly IFødselService fødselService;


        public FødselController(IFødselService fødselService)
        {

            this.fødselService = fødselService;

        }

        [HttpGet(Name = "GetFødsel")]
        public IEnumerable<Fødsel> Get()
        {
            return fødselService.getAll();
        }

        [HttpPost(Name = "PostFødsel")]
        public Fødsel Post(DTOFødsel fødselDTO)
        {
             return fødselService.add(fødselDTO);
        }
    }
}