using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;
using System;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class D�dsfallController : ControllerBase
    {
        private readonly ID�dsfallRepository d�dsfallRepository;

        private static List<D�dsfall> d�dsfallListe = new List<D�dsfall>()
        {
            new D�dsfall(){person = new Person() {Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312}, d�dsTid = new DateTime(2022, 12, 24, 7, 0, 0), d�ds�rsak = "Ukjent" },
            new D�dsfall(){person = new Person() {Fornavn = "Trond", Etternavn = "�rhus", Personnummer = 12312312312}, d�dsTid = new DateTime(2022, 12, 27, 13, 10, 22), d�ds�rsak = "Sorg" }
        };

        private readonly ILogger<D�dsfallController> _logger;

        public D�dsfallController(ILogger<D�dsfallController> logger, ID�dsfallRepository d�dsfallRepository)
        {
            _logger = logger;
            this.d�dsfallRepository = d�dsfallRepository;
        }

        [HttpGet(Name = "GetD�dsfall")]
        public IEnumerable<D�dsfall> Get()
        {
            var res = d�dsfallRepository.GetAll();
            return res;
        }

        [HttpPost(Name = "PostD�dsfall")]
        public D�dsfall Post(D�dsfall d�dsfall)
        {

            d�dsfall = d�dsfallRepository.add(d�dsfall);

            return d�dsfall;
        }
    }
}