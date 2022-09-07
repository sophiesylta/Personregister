using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personregister.Application.Contracts;

namespace Personregister.Application
{
    public class NavnService : INavnService
    {
        public (string fornavn, string etternavn) getNavn(long personnummer)
        {
            switch (personnummer)
            {
                case 12312312312:
                    return ("Sophie", "Sylta");
                case 23423423423:
                    return ("Trond", "Århus");
                case 56756756756:
                    return ("Eva", "Århus");
                default:
                    return ("Ukjent", "Ukjent");
            }
        }
    }
}
