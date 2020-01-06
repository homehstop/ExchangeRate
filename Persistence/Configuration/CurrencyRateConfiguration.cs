using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configuration
{
    class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.HasKey(e => new { e.CurrencyRateId })
                .IsClustered(false);

            builder.Property(e => e.BidPrice).HasMaxLength(40);
            builder.Property(e => e.AskPrice).HasMaxLength(40);
            builder.Property(e => e.LastRefreshed).HasMaxLength(25);
        }
    }
}
