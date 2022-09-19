using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;


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
        public IEnumerable<F�dsel> Get()
        {
            return f�dselService.getAll();
        }

        [HttpPost(Name = "PostF�dsel")]
        public F�dsel Post(DTOF�dsel f�dselDTO)
        {
            var f�dsel = new F�dsel()
            {
                mor = new Person() { Personnummer = f�dselDTO.personnummerMor },
                far = new Person() { Personnummer = f�dselDTO.personnummerFar },
                barn = f�dselDTO.barn,
                f�dselTid = f�dselDTO.f�dselTid
                
            };
            
             f�dsel = f�dselService.add(f�dsel);

            return f�dsel;
        }
    }
}