using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using ExchangeRate.Models.Common;
using ExchangeRate.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeRate.Models
{
    public class TokenDbContext : DbContext
    {
        public TokenDbContext(DbContextOptions<TokenDbContext> options)
            : base (options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
        }

        public DbSet<MetaData> MetaData { get; set; }
    }
}
