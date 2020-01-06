using Microsoft.EntityFrameworkCore;

namespace ExchangeRate.Models
{
    public class CurrencyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExchangeDB;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Currency>().HasKey(p => p.CurrencyId);
            modelBuilder.Entity<ToCurrency>().HasKey(p => p.ToCurrencyId);
            modelBuilder.Entity<CurrencyMonthly>().HasKey(p => p.CurrencyMonthlyId);
            modelBuilder.Entity<Monthly>().HasKey(p => p.MonthlyId);
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
