using Microsoft.EntityFrameworkCore;
using Personregister.Domene;

namespace Personregister.Infrastructure.Persistence.Context
{
    public class Personregistercontext : DbContext
    {

        public Personregistercontext(DbContextOptions<Personregistercontext> options) : base(options) { }

        public DbSet<Person> Personer { get; set; }

        public DbSet<Fødsel> Fødsler { get; set; }

        public DbSet<Dødsfall> Dødsfall { get; set; }

    }
}
