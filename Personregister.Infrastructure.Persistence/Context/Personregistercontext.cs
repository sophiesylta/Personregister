using Microsoft.EntityFrameworkCore;
using Personregister.Domene;

namespace Personregister.Infrastructure.Persistence.Context
{
    public class Personregistercontext : DbContext
    {

        public Personregistercontext(DbContextOptions<Personregistercontext> options) : base(options) { }

        // Initialiser DbSet-ene med null-forgiving operator for å fjerne compiler warning CS8618, vi vet at base-konstruktøren initialiserer disse DbSet-ene!
        public DbSet<Person> Personer { get; set; } = null!;

        public DbSet<Fødsel> Fødsler { get; set; } = null!;

        public DbSet<Dødsfall> Dødsfall => Set<Dødsfall>(); // Alternativ til null-forgiving operator

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().Ignore(x => x.Fødselsnummer);
            modelBuilder.Entity<Person>().HasIndex(u => u._Fødselsnummer).IsUnique();
            modelBuilder.Entity<Person>().HasIndex(e => e.Kallenavn).IsUnique();
        }

    }
}
