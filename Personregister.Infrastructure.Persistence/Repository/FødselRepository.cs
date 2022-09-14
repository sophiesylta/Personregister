using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Personregister.Application;
using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{

    public class FødselRepository : IFødselRepository
    {
        private readonly ILogger<FødselRepository> _logger;
        private Personregistercontext personregistercontext;

        public FødselRepository(ILogger<FødselRepository> logger, Personregistercontext Personregistercontext, INavnService navnService)
        {

            personregistercontext = Personregistercontext;
            _logger = logger;
        }

        public Fødsel add(Fødsel fødsel)
        {
            personregistercontext.Fødsler.Add(fødsel);
            personregistercontext.SaveChanges();
            return fødsel;
        }

        public List<Fødsel> getAll()
        {
            return personregistercontext.Fødsler.Include(f => f.mor).Include(f => f.far).Include(f => f.barn).ToList();
        }

       
    }
}
