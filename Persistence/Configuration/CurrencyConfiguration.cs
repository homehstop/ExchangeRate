using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configuration
{
    class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(e => new { e.CurrencyId })
                .IsClustered(false);

            builder.Property(e => e.CurrencyName).HasMaxLength(50);
            builder.Property(e => e.CurrencyCode).HasMaxLength(15);
            

            builder.HasOne(e => e.CurrencyRate)
                .WithMany(e => e.Currency)
                .HasForeignKey(e => e.CurrencyRateId)
                .HasConstraintName("FK_Currency_CurrencyRate");
        }
    }
}
