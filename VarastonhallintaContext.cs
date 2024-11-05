using Microsoft.EntityFrameworkCore;

namespace Varastonhallinta
{
    public class VarastonhallintaContext : DbContext
    {
        public DbSet<Tuote> Tuotteet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Varastonhallinta;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;" +
                "TrustServerCertificate=True;"; ;
            optionsBuilder.UseSqlServer(connection);
        }
    }
}

