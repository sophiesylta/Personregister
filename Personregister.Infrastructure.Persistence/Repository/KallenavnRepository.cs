using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class KallenavnRepository : IKallenavnRepository
    {
        private readonly Personregistercontext personregistercontext;
        public KallenavnRepository(Personregistercontext personregistercontext)
        {
            this.personregistercontext = personregistercontext;
        }

        public List<Person> getKallenavnListe(string kallenavn)
        {
            return personregistercontext.Personer.Where(e => e.Kallenavn.Contains(kallenavn)).OrderByDescending(e => e.Kallenavn).ToList();

            

        }
    }
}
