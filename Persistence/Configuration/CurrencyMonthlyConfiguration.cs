using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configuration
{
    class CurrencyMonthlyConfiguration : IEntityTypeConfiguration<CurrencyMonthly>
    {
        public void Configure(EntityTypeBuilder<CurrencyMonthly> builder)
        {
            builder.HasKey(e => new { e.CurrencyMonthlyId })
                .IsClustered(false);

            builder.Property(e => e.LastRefreshed).HasMaxLength(25);
            builder.Property(e => e.MonthlyApiUrl).HasMaxLength(200);

            builder.HasOne(e => e.Currency)
                .WithMany(e => e.CurrencyMonthly)
                .HasForeignKey(e => e.CurrencyId)
                .HasConstraintName("FK_CurrencyMontly_Currency");
        }
    }
}
