using Microsoft.EntityFrameworkCore;
using PropertyServices.Persistence.Entities;

namespace PropertyServices.Persistence
{
    public class FundaDbContext : DbContext
    {
        public FundaDbContext(DbContextOptions<FundaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Makelaar> Makelaars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Makelaar>().HasKey(x => x.Id);
            modelBuilder.Entity<Property>().HasKey(x => x.Id);
        }
    }
}
