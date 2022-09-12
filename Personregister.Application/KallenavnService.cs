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
            var kallenavn = fornavn.Substring(0, 2) + etternavn.Substring(0,2);
            kallenavn = kallenavn.ToLower();
            return kallenavn;
        }
    }
}
