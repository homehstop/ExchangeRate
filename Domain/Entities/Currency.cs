using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public float BidPrice { get; set; }
        public float AskPrice { get; set; }
        public string LastRefreshed { get; set; }
        public string ToCurrencyCode { get; set; }
        public string FromCurrencyCode { get; set; }

        [JsonIgnore]
        public List<CurrencyMonthly> CurrencyMonthly { get; set; }
    }
}
