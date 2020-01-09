using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions options)
            : base(options)
        { }

     //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     //         => optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExchangeDB;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
              => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyDbContext).Assembly);

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<CurrencyMonthly> CurrencyMonthlies { get; set; }
        public DbSet<Monthly> Monthlies { get; set; }
    }
}
