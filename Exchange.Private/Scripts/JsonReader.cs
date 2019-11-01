using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Exchange.Private.DataTypes;

namespace Exchange.Private.Scripts
{
    public class JsonReader
    {
        private ExchangeRate exchangeRate { get; set; }

        public JsonReader(ExchangeRate meta) => exchangeRate = meta;
        

        private JToken SetJsonObject(JObject jData, string objectName)
        {
            return jData[objectName];
        }

        private string GetJsonValue(JToken jToken, string name)
        {
            return jToken[name].ToString();
        }

        public void Read(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string jsonRaw = reader.ReadToEnd();

                JObject jsonData = JObject.Parse(jsonRaw);

                JToken jsonObject0 = SetJsonObject(jsonData, "Realtime Currency Exchange Rate");


                exchangeRate.To = GetJsonValue(jsonObject0, "3. To_Currency Code");
                exchangeRate.LastRefreshed = GetJsonValue(jsonObject0, "6. Last Refreshed");
                exchangeRate.From = GetJsonValue(jsonObject0, "1. From_Currency Code");
                exchangeRate.ExchangeRateString = GetJsonValue(jsonObject0, "5. Exchange Rate");
                exchangeRate.BindPrice = GetJsonValue(jsonObject0, "8. Bid Price");
                exchangeRate.AskPrice = GetJsonValue(jsonObject0, "9. Ask Price");
            }
        }

        public ExchangeRate GetExchangeRate()
        {
            return exchangeRate;
        }

    }
}
