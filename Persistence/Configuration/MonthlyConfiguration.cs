using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configuration
{
    class MonthlyConfiguration : IEntityTypeConfiguration<Monthly>
    {
        public void Configure(EntityTypeBuilder<Monthly> builder)
        {
            builder.HasKey(e => new { e.MonthlyId, e.Published})
                .IsClustered(false);

            builder.Property(e => e.Published).HasMaxLength(25);
            builder.Property(e => e.Open).HasMaxLength(40);
            builder.Property(e => e.High).HasMaxLength(40);
            builder.Property(e => e.Low).HasMaxLength(40);
            builder.Property(e => e.Close).HasMaxLength(40);

            builder.HasOne(e => e.CurrencyMonthly)
                .WithMany(e => e.Monthly)
                .HasForeignKey(e => e.MonthlyId)
                .HasConstraintName("FK_Montly_CurrencyMontly");
        }
    }
}
