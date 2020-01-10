using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configuration
{
    class CurrencyMonthlyConfiguration : IEntityTypeConfiguration<CurrencyMonthly>
    {
        public void Configure(EntityTypeBuilder<CurrencyMonthly> builder)
        {
            builder.HasKey(e => new {e.Id, e.Published});

            builder.Property(e => e.Open).HasMaxLength(40);
            builder.Property(e => e.High).HasMaxLength(40);
            builder.Property(e => e.Low).HasMaxLength(40);
            builder.Property(e => e.Close).HasMaxLength(40);

            builder.Ignore(e => e.Currency);

            builder.HasOne(e => e.Currency)
                .WithMany(e => e.CurrencyMonthly)
                .HasForeignKey(e => e.Id) //Id from CurrencyMonthly
                .HasConstraintName("FK_CurrencyMonthly_Currency");
        }
    }
}
