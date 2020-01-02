using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Api.JsonObjects
{
    public class RealtimeMonthlyCurrencyRate : ICurrencyApi
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public MonthlyMetaData MonthlyMetaData { get; set; }
        
        public RealtimeMonthlyCurrencyRate()
        {
            CurrencySeries = new HashSet<CurrencySeries>();
        }
        
        public ICollection<CurrencySeries> CurrencySeries { get; set; }
    }

    public class MonthlyMetaData
    {
        [JsonProperty(PropertyName = "2. From Symbol")]
        string From { get; set; }

        [JsonProperty(PropertyName = "3. To Symbol")]
        string To { get; set; }

        [JsonProperty(PropertyName = "4. Last Refreshed")]
        string LastRefreshed { get; set; }
    }
}
