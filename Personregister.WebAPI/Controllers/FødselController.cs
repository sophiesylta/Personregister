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
    public class FødselController : ControllerBase
    {
        private static List<Fødsel> fødselListe = new List<Fødsel>()
        {
          new Fødsel(){mor = new Person() {Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312}, far = new Person() {Fornavn = "Trond", Etternavn = "Århus", Personnummer = 12312312312}, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() {Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756} }

        };

        private readonly ILogger<FødselController> _logger;
        private readonly IFødselRepository _fødselRepository;
        private readonly IFødselService fødselService;
        private readonly INavnService navnService;

        public FødselController(ILogger<FødselController> logger, IFødselRepository fødselRepository, IFødselService fødselService, INavnService navnService)
        {
            _logger = logger;
            _fødselRepository = fødselRepository;
            this.fødselService = fødselService;
            this.navnService = navnService;
        }

        [HttpGet(Name = "GetFødsel")]
        public IEnumerable<Fødsel> Get()
        {
            return _fødselRepository.getAll();
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