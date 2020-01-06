using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Infrastructure.Api;
using Infrastructure.Api.JsonObjects;

namespace Infrastructure.Api.Parser
{
    public class JsonParser
    {
        public ICurrencyApi Parse(string fileName, EntityType entityType)
        {
            using (var reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();

                var output = Filter(json, entityType);
                return output;
            }
        }

        ICurrencyApi Filter(string json, EntityType entityType)
        {
            switch (entityType)
            {
                case EntityType.Daily:
                {
                    var Object = JsonConvert
                            .DeserializeObject<RealtimeCurrency>(json);
                    return Object;
                }
                case EntityType.Monthly:
                {
                    var Object = JsonConvert
                            .DeserializeObject<RealtimeMonthlyCurrencyRate>(json);
                    Object.CurrencySeries = CurrencySeriesFilter(json);
                    return Object;
                }
                default:
                    throw new Exception("Invalid parser entity type.");
            }
        }

        float ConvertToFloat(string text)
        {
            float x;
            if (float.TryParse(text, out x))
            {
                return x = float.Parse(text);
            }
            else
            {
                throw new Exception("Can not convert to float.");
            }
        }

        ICollection<CurrencySeries> CurrencySeriesFilter(string json)
        {
            JObject jData = JObject.Parse(json);
            JToken jObjects = jData["Time Series FX (Monthly)"];
            var tokens = (JObject)jObjects;
            ICollection<CurrencySeries> tempList = new List<CurrencySeries>();
            CurrencySeries temp;

            foreach (var i in tokens)
            {
                temp = new CurrencySeries();

                var a = ((JObject)i.Value).Properties().Values().ToArray();

                temp.Refreshed = i.Key.ToString();
                temp.Open = ConvertToFloat(a[0].ToString());
                temp.High = ConvertToFloat(a[1].ToString());
                temp.Low =  ConvertToFloat(a[2].ToString());
                temp.Close = ConvertToFloat(a[3].ToString());
                tempList.Add(temp);
            }

            return tempList;
        }

        public static JsonParser Create()
        {
            return new JsonParser();
        }
    }
}
