using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public int CurrencyRateId { get; set; }
        public int CurrencyMonthlyId { get; set; }

        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public CurrencyRate CurrencyRate { get; set; }
        public CurrencyMonthly CurrencyMonthly { get; set; }
    }
}
