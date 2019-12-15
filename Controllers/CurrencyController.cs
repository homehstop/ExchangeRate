using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExchangeRate.Models;
using Microsoft.EntityFrameworkCore;


namespace ExchangeRate.Controllers
{
    public class CurrencyController : Controller
    {

        Currency CreateEntity()
        {
            Monthly monthly = new Monthly
            {
               
                Open = 10f,
                High = 555.42f,
                Close = 0.1f,
                Low = -1.0f
            };

            CurrencyMonthly currencyMonthly = new CurrencyMonthly
            {
               
                LastRefreshed = DateTime.Now.ToString(),
                Monthlies = new List<Monthly> { monthly }
            };

            ToCurrency toCurrency = new ToCurrency
            {
               
                ToCurrencyName = "US dollar",
                ExchangeRate = 12.1f,
                BidPrice = 12.32f,
                AskPrice = 1.0f,
                LastRefreshed = DateTime.Now.ToString(),
                CurrencyMonthlies = new List<CurrencyMonthly> { currencyMonthly }

            };

            Currency currency = new Currency
            {
                
                CurrencyName = "US dollar",
                CurrencyCode = "USD",
                ToCurrencies = new List<ToCurrency> { toCurrency }

            };

            return currency;
        }


        public ViewResult Index()
        {

            using (var db = new CurrencyDbContext())
            {
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Currencies] ON");

                db.Currencies.Add(CreateEntity());
                db.Currencies.Add(CreateEntity());
                db.SaveChanges();

                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Currencies] OFF");
            }
            return View();
        }
    }
}
