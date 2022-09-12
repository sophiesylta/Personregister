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

                case 11111111111:
                    return ("Donald", "Duck");

                case 22222222222:
                    return ("Minnie", "Mouse");

                case 33333333333:
                    return ("Dolly", "Duck");

                case 44444444444:
                    return ("Ole", "Duck-Mouse");

                case 55555555555:
                    return ("Dole", "Duck-Mouse");

                case 66666666666:
                    return ("Doffen", "Duck-Mouse");

                default:
                    return ("Ukjent", "Ukjent");
            }
        }
    }
}
