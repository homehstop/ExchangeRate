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
        
        [JsonProperty(PropertyName = "Time Series FX (Monthly)")]
        public CurrencySeries CurrencySeries { get; set; }
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

    public class CurrencySeries
    { 
        [JsonProperty(PropertyName = "1. open")]
        public float Open { get; set; }

        [JsonProperty(PropertyName = "2. high")]
        public float High { get; set; }

        [JsonProperty(PropertyName = "3. low")]
        public float Low { get; set; }

        [JsonProperty(PropertyName = "4. close")]
        public float Close { get; set; }
    }
}
