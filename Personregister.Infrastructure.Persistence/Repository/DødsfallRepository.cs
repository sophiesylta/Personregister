using Microsoft.EntityFrameworkCore;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.Infrastructure.Persistence.Context;

namespace Personregister.Infrastructure.Persistence.Repository
{
    public class DødsfallRepository : IDødsfallRepository
    {
        private readonly Personregistercontext personregistercontext;
        public DødsfallRepository(Personregistercontext personregistercontext) 
        {
            this.personregistercontext = personregistercontext;

        }

        public Dødsfall add(Dødsfall dødsfall)
        {
            personregistercontext.Dødsfall.Add(dødsfall);
            personregistercontext.SaveChanges();

            return dødsfall;
        }

        public List<Dødsfall> GetAll()
        {
            return personregistercontext.Dødsfall.Include(d => d.person).ToList();
        }

        public Dødsfall getDødsfall(long personnummer)
        {
            return personregistercontext.Dødsfall.FirstOrDefault(e => e.person._Fødselsnummer == personnummer.ToString())!;
        }
    }
}
