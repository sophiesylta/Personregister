using Microsoft.EntityFrameworkCore;

namespace Personregister.WebAPI.Models
{
    public class Personregistercontext : DbContext
    {
    
        public Personregistercontext(DbContextOptions<Personregistercontext> options) : base(options) { }

        public DbSet<Person> Personer { get; set; }

        public DbSet<Fødsel> Fødsler { get; set; }

    }
}
