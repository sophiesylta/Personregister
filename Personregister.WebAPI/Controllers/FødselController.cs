using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Repository;
using Personregister.WebAPI.Models;
using System;
using Personregister.WebAPI.Models;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class F�dselController : ControllerBase
    {
        private static List<F�dsel> f�dselListe = new List<F�dsel>()
        {
          new F�dsel(){mor = new Person() {Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312}, far = new Person() {Fornavn = "Trond", Etternavn = "�rhus", Personnummer = 12312312312}, f�dselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() {Fornavn = "Eva", Etternavn = "�rhus", Personnummer = 56756756756} }

        };

        private readonly ILogger<F�dselController> _logger;
        private readonly IF�dselRepository _f�dselRepository;
        private readonly IF�dselService f�dselService;
        private readonly INavnService navnService;

        public F�dselController(ILogger<F�dselController> logger, IF�dselRepository f�dselRepository, IF�dselService f�dselService, INavnService navnService)
        {
            _logger = logger;
            _f�dselRepository = f�dselRepository;
            this.f�dselService = f�dselService;
            this.navnService = navnService;
        }

        [HttpGet(Name = "GetF�dsel")]
        public IEnumerable<F�dsel> Get()
        {
            return _f�dselRepository.getAll();
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