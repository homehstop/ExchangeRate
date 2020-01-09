using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public int CurrencyRateId { get; set; }
        public int CurrencyMonthlyId { get; set; }

        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        [JsonIgnore]
        public CurrencyRate CurrencyRate { get; set; }
        [JsonIgnore]
        public CurrencyMonthly CurrencyMonthly { get; set; }
    }
}
