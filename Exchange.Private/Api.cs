using System;
using System.Collections.Generic;
using System.Text;

using Exchange.Private.DataTypes;
using Exchange.Private.Scripts;


namespace Exchange.Private
{
    class APITokens
    {
        public string token { get; set; }
    }

    public class Api
    {
        private List<APITokens> tokens = new List<APITokens>()
        {
            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=EUR&apikey=JIM07LC18T4I2AHC"},
            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=UAH&apikey=JIM07LC18T4I2AHC"},
            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=CHF&apikey=JIM07LC18T4I2AHC"},
        };

        public ExchangeDataList Init()
        {

            int z = 0;
            const string api = "alphavantage";
            const string type = ".json";
            ExchangeRateData temp;
            ExchangeDataList temp0 = new ExchangeDataList();
            temp0.ExchangeRates = new List<ExchangeRateData>();

            foreach (APITokens i in tokens)
            {
                temp = new ExchangeRateData();
                DownloadScript.Download(i.token, api + z.ToString() + type);
                temp = JsonReader.Read(api + z.ToString() + type, temp);

                z++;
                
                temp0.ExchangeRates.Add(temp);
                temp = null;
            }
            return temp0;
        }
    }
}
