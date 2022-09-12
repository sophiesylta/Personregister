using Microsoft.AspNetCore.Mvc;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.WebAPI.Models;
using System;

namespace Personregister.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DødsfallController : ControllerBase
    {
        private readonly IDødsfallRepository dødsfallRepository;

        private static List<Dødsfall> dødsfallListe = new List<Dødsfall>()
        {
            new Dødsfall(){person = new Person() {Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312}, dødsTid = new DateTime(2022, 12, 24, 7, 0, 0), dødsårsak = "Ukjent" },
            new Dødsfall(){person = new Person() {Fornavn = "Trond", Etternavn = "Århus", Personnummer = 12312312312}, dødsTid = new DateTime(2022, 12, 27, 13, 10, 22), dødsårsak = "Sorg" }
        };

        private readonly ILogger<DødsfallController> _logger;

        public DødsfallController(ILogger<DødsfallController> logger, IDødsfallRepository dødsfallRepository)
        {
            _logger = logger;
            this.dødsfallRepository = dødsfallRepository;
        }

        [HttpGet(Name = "GetDødsfall")]
        public IEnumerable<Dødsfall> Get()
        {
            var res = dødsfallRepository.GetAll();
            return res;
        }

        [HttpPost(Name = "PostDødsfall")]
        public Dødsfall Post(Dødsfall dødsfall)
        {

            dødsfall = dødsfallRepository.add(dødsfall);

            return dødsfall;
        }
    }
}