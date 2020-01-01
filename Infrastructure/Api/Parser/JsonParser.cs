using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

                return Filter(json, entityType);
            }
        }

        private ICurrencyApi Filter(string json, EntityType entityType)
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
                    return Object;
                }
                default:
                    throw new Exception("Invalid parser entity type");
            }
        }

        public static JsonParser Create()
        {
            return new JsonParser();
        }
    }
}
