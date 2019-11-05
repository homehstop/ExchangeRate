using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;


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

        private static string JHelper()
        {
            return null;
        }

        public static List<ChartModel> ChartJsonReader(string file, List<ChartModel> chartModelList)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string jsonRaw = reader.ReadToEnd();

                JObject jsonData = JObject.Parse(jsonRaw);

                JToken jsonObject = jsonData["Time Series FX (Monthly)"];

                var tokens = (JObject)jsonObject;

                ChartModel temp;

                

                foreach (var i in tokens)
                {
                    temp = new ChartModel();

                    var z = ((JObject)i.Value).Properties().Values().ToArray();

                    temp.Date = i.Key.ToString();
                    temp.Open =  StringParserToInt.Parse(z[0].ToString());
                    temp.High =  StringParserToInt.Parse(z[1].ToString());
                    temp.Low =   StringParserToInt.Parse(z[2].ToString());
                    temp.Close = StringParserToInt.Parse(z[3].ToString());
                                                             
                    chartModelList.Add(temp);
                    temp = null;
                }

                return chartModelList;
            }
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
