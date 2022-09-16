using Personregister.Application.Contracts;
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

        public string getKallenavn(string fornavn, string etternavn)
        {
            // finn på noe annet her
            if (fornavn == null ) fornavn = "aa";
            if (etternavn == null) etternavn = "aa";

            var kallenavn = fornavn.Substring(0, Math.Min(fornavn.Length,2)) + etternavn.Substring(0, Math.Min(etternavn.Length, 2));
            kallenavn = kallenavn.ToLower();
            return kallenavn;
        }
    }
}
