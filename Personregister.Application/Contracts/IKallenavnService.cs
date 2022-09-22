using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application.Contracts
{
    public interface IKallenavnService
    {
        public string getKallenavn(string fornavn, string etternavn);
        public string getUniktKallenavn(string kallenavn);
    }
}
