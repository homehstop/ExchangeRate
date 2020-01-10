using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
    public class CurrencyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExchangeDB;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyDbContext).Assembly);

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyMonthly> CurrencyMonthlies { get; set; }
    }
}
