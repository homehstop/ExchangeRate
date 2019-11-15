using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRate.Models.Entities
{
    public static class SeedData
    {
        public static void Ensure(IApplicationBuilder app)
        { 
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TokenDbContext>();

                context.Database.Migrate();
                if (!context.MetaData.Any())
                {
                    context.MetaData.AddRange(Api.GetMetaData());
                }

                context.SaveChanges();
            }
        }
    }
}
