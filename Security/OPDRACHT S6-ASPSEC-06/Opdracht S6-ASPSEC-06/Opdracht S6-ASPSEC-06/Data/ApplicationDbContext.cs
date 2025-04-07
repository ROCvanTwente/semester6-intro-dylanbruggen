using Microsoft.EntityFrameworkCore;
using Opdracht_S6_ASPSEC_06.Models;

namespace Opdracht_S6_ASPSEC_06.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Studenten { get; set; }
        public DbSet<Vak> Vakken { get; set; }
        public DbSet<ToetsResultaat> ToetsResultaten { get; set; }
    }
}
