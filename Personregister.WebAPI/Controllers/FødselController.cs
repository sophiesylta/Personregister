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
             return f�dselService.add(f�dselDTO);
        }
    }
}