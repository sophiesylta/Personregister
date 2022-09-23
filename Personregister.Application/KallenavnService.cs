using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application
{
    public class KallenavnService : IKallenavnService
    {
        private readonly IPersonRepository personRepository;
        public KallenavnService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public string getKallenavn(string fornavn, string etternavn)
        {
            // finn på noe annet her
            if (fornavn == null ) fornavn = "aa";
            if (etternavn == null) etternavn = "aa";

            var kallenavn = fornavn.Substring(0, Math.Min(fornavn.Length,2)) + etternavn.Substring(0, Math.Min(etternavn.Length, 2));
            kallenavn = kallenavn.ToLower();

            return getUniktKallenavn(kallenavn);
        }

        public string getUniktKallenavn(string kallenavn)
        {
            if (string.IsNullOrEmpty(kallenavn)) 
                kallenavn = "aaaa";

            int? maxnumber =
                personRepository
                .QueryPerson().Where(e=>e.Kallenavn.Contains(kallenavn)).Select(e=>e.Kallenavn)
                .Select(e => e.Replace(kallenavn, ""))
                .Where(e => !string.IsNullOrEmpty(e))
                .Select(e => int.Parse(e))
                .Max();

            return maxnumber.HasValue
                ? kallenavn + maxnumber.HasValue + 1
                : kallenavn + 1;
        }
    }
}
