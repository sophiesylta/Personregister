using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;


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
            var fødsel = new Fødsel()
            {
                mor = new Person() { Personnummer = fødselDTO.personnummerMor },
                far = new Person() { Personnummer = fødselDTO.personnummerFar },
                barn = fødselDTO.barn,
                fødselTid = fødselDTO.fødselTid
                
            };
            
             fødsel = fødselService.add(fødsel);

            return fødsel;
        }
    }
}