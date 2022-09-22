using Personregister.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application.Contracts.Repository
{
    public interface IKallenavnRepository
    {
        public List<Person> getKallenavnListe(string kallenavn);
    }
}
