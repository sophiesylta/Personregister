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
        public IEnumerable<DTOGetFødsel> Get()
        {
            return fødselService.getAll();
        }

        [HttpPost(Name = "PostFødsel")]
        public Boolean Post(DTOFødsel fødselDTO)
        {
           return fødselService.add(fødselDTO);

        }
    }
}