using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Persistence.Configuration
{
    class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(e => new {e.Id});
            
            builder.Property(e => e.ToCurrencyCode).HasMaxLength(15);
            builder.Property(e => e.FromCurrencyCode).HasMaxLength(15);
            builder.Property(e => e.LastRefreshed).HasMaxLength(25);
            builder.Property(e => e.AskPrice).HasMaxLength(40);
            builder.Property(e => e.BidPrice).HasMaxLength(40);

            builder.Ignore(e => e.CurrencyMonthly);
        }
    }
}
