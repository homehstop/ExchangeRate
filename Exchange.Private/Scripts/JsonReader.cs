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
        private static JToken SetJsonObject(JObject jData, string objectName)
        {
            return jData[objectName];
        }

        private static string GetJsonValue(JToken jToken, string name)
        {
            return jToken[name].ToString();
        }

        public static ExchangeRateData Read(string file, ExchangeRateData exchangeRateDataType)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string jsonRaw = reader.ReadToEnd();

                JObject jsonData = JObject.Parse(jsonRaw);

                JToken jsonObject0 = SetJsonObject(jsonData, "Realtime Currency Exchange Rate");


                exchangeRateDataType.To = GetJsonValue(jsonObject0, "3. To_Currency Code");
                exchangeRateDataType.LastRefreshed = GetJsonValue(jsonObject0, "6. Last Refreshed");
                exchangeRateDataType.From = GetJsonValue(jsonObject0, "1. From_Currency Code");
                exchangeRateDataType.ExchangeRateString = GetJsonValue(jsonObject0, "5. Exchange Rate");
                exchangeRateDataType.BindPrice = GetJsonValue(jsonObject0, "8. Bid Price");
                exchangeRateDataType.AskPrice = GetJsonValue(jsonObject0, "9. Ask Price");

                return exchangeRateDataType;
            }
        }
    }
}
