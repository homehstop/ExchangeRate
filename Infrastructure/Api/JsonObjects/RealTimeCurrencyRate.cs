using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Api.JsonObjects
{
    public class RealtimeCurrency : ICurrencyApi
    {
        [JsonProperty(PropertyName = "Realtime Currency Exchange Rate")]
        public RealtimeCurrencyRate RealtimeCurrencyRate;
    }

    public class RealtimeCurrencyRate
    {
        [JsonProperty(PropertyName = "1. From_Currency Code")]
        string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "2. From_Currency Name")]
        string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "3. To_Currency Code")]
        string ToCurrencyCode { get; set; }

        [JsonProperty(PropertyName = "5. Exchange Rate")]
        float ExchangeRate { get; set; }

        [JsonProperty(PropertyName = "8. Bid Price")]
        float BidPrice { get; set; }

        [JsonProperty(PropertyName = "9. Ask Price")]
        float AskPrice { get; set; }

        [JsonProperty(PropertyName = "6. Last Refreshed")]
        string LastRefreshed { get; set; }
    }
}
