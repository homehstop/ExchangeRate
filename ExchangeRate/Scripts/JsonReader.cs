using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ExchangeRate.Models.Common;

namespace ExchangeRate.Scripts
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

                JToken jName = jsonData["Meta Data"];

                JToken jsonObject = jsonData["Time Series FX (Monthly)"];

                var tokens = (JObject)jsonObject;

                ChartModel temp;

                

                foreach (var i in tokens)
                {
                    temp = new ChartModel();

                    temp.Name = jName["3. To Symbol"].ToString();

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

        public static MetaData Read(string file, MetaData metaData, int id)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string jsonRaw = reader.ReadToEnd();

                JObject jsonData = JObject.Parse(jsonRaw);

                JToken jsonObject0 = SetJsonObject(jsonData, "Realtime Currency Exchange Rate");

                metaData.MetaDataId = id;
                metaData.ToCurrency = GetJsonValue(jsonObject0, "3. To_Currency Code");
                metaData.LastRefreshed = GetJsonValue(jsonObject0, "6. Last Refreshed");
                metaData.Currency= GetJsonValue(jsonObject0, "1. From_Currency Code");
                metaData.ExchangeRateString = GetJsonValue(jsonObject0, "5. Exchange Rate");
                metaData.BindPrice = GetJsonValue(jsonObject0, "8. Bid Price");
                metaData.AskPrice = GetJsonValue(jsonObject0, "9. Ask Price");

                

                return metaData;
            }
        }
    }
}
