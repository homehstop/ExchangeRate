using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Api;
using Infrastructure.Api.JsonObjects;
using Domain.Entities;

namespace Persistence.Seeding
{
    public static class CurrencySeeding
    {
        public static void Ensure(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CurrencyDbContext>();

                //TODO: create function for seeding
                var api = Api.Create();
                api.Init();

                context.Database.Migrate();

                if(!context.Currencies.Any())
                {
                    MigrateCurrency(api, context);
                }
            }
        }

        static void MigrateCurrency(Api api, CurrencyDbContext context)
        {
            var currList = api.GetRealtimeCurrencies;
            var montList = api.GetRealtimeMonthlyCurrencyRates;

            foreach (var i in currList)
            {
                string currCode = i.RealtimeCurrencyRate.FromCurrencyCode;
                string toCurrCode = i.RealtimeCurrencyRate.ToCurrencyCode;

                List<CurrencyMonthly> currencyMonthly = 
                        MigrateMonthly(montList, currCode, toCurrCode);

                Currency currency = new Currency()
                {
                    BidPrice = i.RealtimeCurrencyRate.BidPrice,
                    AskPrice = i.RealtimeCurrencyRate.AskPrice,
                    LastRefreshed = i.RealtimeCurrencyRate.LastRefreshed,
                    ToCurrencyCode = i.RealtimeCurrencyRate.ToCurrencyCode,
                    FromCurrencyCode = i.RealtimeCurrencyRate.FromCurrencyCode,
                    CurrencyMonthly = currencyMonthly
                };
                context.Currencies.AddRange(currency);
                context.SaveChanges();
            }
        }

        static List<CurrencyMonthly> MigrateMonthly(List<RealtimeMonthlyCurrencyRate> montList, string currCode, string toCurrCode)
        {
            List<CurrencyMonthly> currencyMonthlies = new List<CurrencyMonthly>();

            foreach (var i in montList)
            {
                if (i.MonthlyMetaData.From != currCode || i.MonthlyMetaData.To != toCurrCode)
                    continue;
                else
                {
                    foreach (var z in i.CurrencySeries)
                    {
                        CurrencyMonthly currencyMonthly = new CurrencyMonthly()
                        {
                            Published = z.Refreshed,
                            Open = z.Open,
                            High = z.High,
                            Low = z.Low,
                            Close = z.Close
                        };
                        
                        currencyMonthlies.Add(currencyMonthly);
                    }
                }
            }
            return currencyMonthlies;
        }
    }
}
