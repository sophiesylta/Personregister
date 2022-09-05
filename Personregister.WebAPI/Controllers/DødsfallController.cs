using Microsoft.AspNetCore.Mvc;
using Personregister.WebAPI.Models;
using System;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class D�dsfallController : ControllerBase
    {
        private static List<D�dsfall> d�dsfallListe = new List<D�dsfall>()
        {
            new D�dsfall(){person = new Person() {Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312}, d�dsTid = new DateTime(2022, 12, 24, 7, 0, 0), d�ds�rsak = "Ukjent" },
            new D�dsfall(){person = new Person() {Fornavn = "Trond", Etternavn = "�rhus", Personnummer = 12312312312}, d�dsTid = new DateTime(2022, 12, 27, 13, 10, 22), d�ds�rsak = "Sorg" }
        };

        private readonly ILogger<D�dsfallController> _logger;

        public D�dsfallController(ILogger<D�dsfallController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetD�dsfall")]
        public IEnumerable<D�dsfall> Get()
        {
            return d�dsfallListe;
        }

        [HttpPost(Name = "PostD�dsfall")]
        public IEnumerable<D�dsfall> Post(D�dsfall d�dsfall)
        {
            d�dsfallListe.Add(d�dsfall);

            return d�dsfallListe;
        }
    }
}