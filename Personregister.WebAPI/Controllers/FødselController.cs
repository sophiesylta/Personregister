using Microsoft.AspNetCore.Mvc;
using Personregister.WebAPI.Models;
using System;

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

        public FødselController(ILogger<FødselController> logger, IFødselRepository fødselRepository)
        {
            _logger = logger;
            _fødselRepository = fødselRepository;
        }

        [HttpGet(Name = "GetFødsel")]
        public IEnumerable<Fødsel> Get()
        {
            return _fødselRepository.getAll();
        }

        [HttpPost(Name = "PostFødsel")]
        public Fødsel Post(Fødsel fødsel)
        {
           fødsel = _fødselRepository.add(fødsel);

            return fødsel;
        }
    }
}