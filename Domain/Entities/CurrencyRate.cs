using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CurrencyRate
    {
        public int CurrencyRateId { get; set; }
        public string ApiUrl { get; set; }
        public float BidPrice { get; set; }
        public float AskPrice { get; set; }
        public string LastRefreshed { get; set; }
        public string ToCurrencyCode { get; set; }
        public ICollection<Currency> Currency { get; set; }
    }
}
