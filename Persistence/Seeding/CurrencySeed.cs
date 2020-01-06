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
                string currCode = i.RealtimeCurrencyRate.CurrencyCode;
                string toCurrCode = i.RealtimeCurrencyRate.ToCurrencyCode;

                CurrencyMonthly currencyMonthly = new CurrencyMonthly();
                currencyMonthly = MigrateMonthly(currencyMonthly, montList, currCode, toCurrCode);

                CurrencyRate currencyRate = new CurrencyRate()
                {
                    ToCurrencyCode = i.RealtimeCurrencyRate.ToCurrencyCode,
                    BidPrice = i.RealtimeCurrencyRate.BidPrice,
                    AskPrice = i.RealtimeCurrencyRate.AskPrice,
                    LastRefreshed = i.RealtimeCurrencyRate.LastRefreshed
                };

                Currency currency = new Currency()
                {
                    CurrencyName = i.RealtimeCurrencyRate.CurrencyName,
                    CurrencyCode = i.RealtimeCurrencyRate.CurrencyCode,
                    CurrencyRate = currencyRate,
                    CurrencyMonthly = currencyMonthly
                };

                context.Currencies.AddRange(currency);
                context.SaveChanges();
            }
        }

        static CurrencyMonthly MigrateMonthly(CurrencyMonthly currencyMonthly, List<RealtimeMonthlyCurrencyRate> montList, string currCode, string toCurrCode)
        {
            List<Monthly> monthlies;

            foreach (var i in montList)
            {
                if (i.MonthlyMetaData.From != currCode || i.MonthlyMetaData.To != toCurrCode)
                    continue;
                else
                {
                    monthlies = new List<Monthly>();

                    currencyMonthly = new CurrencyMonthly()
                    {
                        LastRefreshed = i.MonthlyMetaData.LastRefreshed
                    };

                    foreach (var z in i.CurrencySeries)
                    {
                        Monthly item = new Monthly()
                        {
                            Published = z.Refreshed,
                            Open = z.Open,
                            High = z.High,
                            Low = z.Low,
                            Close = z.Close,
                            CurrencyMonthly = currencyMonthly
                        };

                        monthlies.Add(item);
                    }
                    currencyMonthly.Monthly = monthlies;
                }
            }
            return currencyMonthly;
        }
    }
}
