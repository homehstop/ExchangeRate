using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Tests.Entities
{
    public class Entity
    {
        public static Currency CreateEntity()
        {
            Monthly monthly = new Monthly
            {
                Published = "Hello",
                Open = 1.3f,
                High = 22.0f,
                Low = 0.0f,
                Close = -0.1f
            };

            CurrencyMonthly currencyMonthly = new CurrencyMonthly
            {
                LastRefreshed = DateTime.Now.ToString(),
                Monthly = new List<Monthly> { monthly }
            };

            CurrencyRate currencyRate = new CurrencyRate
            {
                ToCurrencyCode = "EUR",
                BidPrice = 1.02f,
                AskPrice = 2.03f,
                LastRefreshed = DateTime.Now.ToString(),
            };

            Currency currency = new Currency
            {
                CurrencyName = "United States Dollar",
                CurrencyCode = "USD",
                CurrencyRate = currencyRate,
                CurrencyMonthly =  currencyMonthly
            };

            return currency;
        }
    }
}
