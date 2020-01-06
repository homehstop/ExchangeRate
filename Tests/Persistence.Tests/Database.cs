using Microsoft.EntityFrameworkCore;
using Domain.Tests.Entities;
using Persistence.Seeding;
using NUnit.Framework;

namespace Persistence.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public void Seed_data()
        {
        }

       // [Test]
       // public void DataBase_Saving_And_Entity()
       // {
       //
       //     using (var db = new CurrencyDbContext())
       //     {
       //         //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Currencies] ON");
       //         //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CurrencyRates] ON");
       //         //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CurrencyMonthlies] ON");
       //         //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Monthlies ON");
       //         
       //         var entity = Entity.CreateEntity();
       //
       //         db.Currencies.Add(entity);
       //         
       //         db.SaveChanges();
       //
       //         //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Currencies] OFF");
       //     }
       //     Assert.Pass();
       // }
       //
       // [Test]
       // public void DataBase_Removind()
       // {
       //     using (var db = new CurrencyDbContext())
       //     {
       //         var entity = Entity.CreateEntity();
       //         db.Currencies.Attach(entity);
       //         db.Currencies.Remove(entity);
       //         db.SaveChanges();
       //     }
       //     Assert.Pass();
       // }
    }
}
