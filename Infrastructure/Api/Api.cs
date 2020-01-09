using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Infrastructure.Api.FileSystem;
using Infrastructure.Api.JsonObjects;
using Infrastructure.Api.Parser;
using Infrastructure.Api.Scripts;
using Domain.Entities;


namespace Infrastructure.Api
{
    public class Api
    {
        class APIToken
        {
            public string CurrencyToken { get; set; }
            public string MonthlyToken { get; set; }
        }
        
        const string fileName = "alphavantage";
        int counter = 0;

        List<APIToken> tokens { get; set; }

        public static Api Create()
        {
            return new Api();
        }

        public List<RealtimeCurrency> GetRealtimeCurrencies = new List<RealtimeCurrency>();
        public List<RealtimeMonthlyCurrencyRate> GetRealtimeMonthlyCurrencyRates = new List<RealtimeMonthlyCurrencyRate>();

        public void Init()
        {
            bool flag;
            var downloader = FileDownloader.Create();
            var parser = JsonParser.Create();
            var dm = DirectoryManager.Create("temp/");
            
            counter = 0;

            if (tokens == null)
                tokens = InitTokens();

            foreach(var i in tokens)
            {
                counter++;
                try
                {
                    //TODO: create function for it 
                    flag = File.Exists(fileName + counter.ToString() + ".json");
                    if (flag == false)
                        throw new FileNotFoundException();

                    flag = File.Exists(fileName + "Monthly" + counter.ToString() + ".json");
                    if (flag == false)
                        throw new FileNotFoundException();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("{0}.\n Downloading ", e.ToString());
                    downloader.Get(i.CurrencyToken, fileName + counter.ToString() + ".json");
                    //Alphavantage 5 api request limitation
                    Thread.Sleep(15000);
                    downloader.Get(i.MonthlyToken, fileName + "Monthly" + counter.ToString() + ".json");
                }
                
                var z = (RealtimeCurrency)
                        parser.Parse(fileName + counter.ToString() + ".json", EntityType.Daily);
                GetRealtimeCurrencies.Add(z);

                var f = (RealtimeMonthlyCurrencyRate)
                        parser.Parse(fileName + "Monthly" + counter.ToString() + ".json", EntityType.Monthly);
                GetRealtimeMonthlyCurrencyRates.Add(f);
            }
        }

        List<APIToken> InitTokens()
        {
            tokens = new List<APIToken>
            {
                new APIToken { CurrencyToken = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=EUR&apikey=JIM07LC18T4I2AHC",
                                MonthlyToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=EUR&apikey=JIM07LC18T4I2AHC" },

                new APIToken { CurrencyToken = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=UAH&apikey=JIM07LC18T4I2AHC", 
                                MonthlyToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=UAH&apikey=JIM07LC18T4I2AHC" },

                new APIToken { CurrencyToken = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=CHF&apikey=JIM07LC18T4I2AHC", 
                                MonthlyToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=CHF&apikey=JIM07LC18T4I2AHC" }
            };

            return tokens;
        }

    }
}
