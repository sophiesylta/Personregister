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

        public F�dselController(ILogger<F�dselController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetF�dsel")]
        public IEnumerable<F�dsel> Get()
        {
            return f�dselListe;
        }

        [HttpPost(Name = "PostF�dsel")]
        public IEnumerable<F�dsel> Post(F�dsel f�dsel)
        {
            f�dselListe.Add(f�dsel);

            return f�dselListe;
        }
    }
}