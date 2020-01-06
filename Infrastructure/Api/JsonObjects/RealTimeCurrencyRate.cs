using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Api.JsonObjects
{
    public class RealtimeCurrency : ICurrencyApi
    {
        //TODO: refactor
        [JsonProperty(PropertyName = "Realtime Currency Exchange Rate")]
        public RealtimeCurrencyRate RealtimeCurrencyRate;
    }

    public class RealtimeCurrencyRate
    {
        [JsonProperty(PropertyName = "1. From_Currency Code")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "2. From_Currency Name")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "3. To_Currency Code")]
        public string ToCurrencyCode { get; set; }

        [JsonProperty(PropertyName = "5. Exchange Rate")]
        public float ExchangeRate { get; set; }

        [JsonProperty(PropertyName = "8. Bid Price")]
        public float BidPrice { get; set; }

        [JsonProperty(PropertyName = "9. Ask Price")]
        public float AskPrice { get; set; }

        [JsonProperty(PropertyName = "6. Last Refreshed")]
        public string LastRefreshed { get; set; }
    }
}
