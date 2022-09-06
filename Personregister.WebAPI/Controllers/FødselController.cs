using Microsoft.AspNetCore.Mvc;
using Personregister.WebAPI.Models;
using System;

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

        public F�dselController(ILogger<F�dselController> logger, IF�dselRepository f�dselRepository)
        {
            _logger = logger;
            _f�dselRepository = f�dselRepository;
        }

        [HttpGet(Name = "GetF�dsel")]
        public IEnumerable<F�dsel> Get()
        {
            return _f�dselRepository.getAll();
        }

        [HttpPost(Name = "PostF�dsel")]
        public F�dsel Post(F�dsel f�dsel)
        {
           f�dsel = _f�dselRepository.add(f�dsel);

            return f�dsel;
        }
    }
}