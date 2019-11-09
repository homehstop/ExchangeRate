using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using ExchangeRate.Models.Common;
using ExchangeRate.Scripts;


namespace ExchangeRate
{
    class APITokens
    {
        public string token { get; set; }
        public string chartToken { get; set; }
    }

    public class Api
    {
        private static List<APITokens> tokensAPI = new List<APITokens>()
        {
            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=EUR&apikey=JIM07LC18T4I2AHC",
                           chartToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=EUR&apikey=JIM07LC18T4I2AHC" },

            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=UAH&apikey=JIM07LC18T4I2AHC",
                           chartToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=UAH&apikey=JIM07LC18T4I2AHC"},

            new APITokens {token = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=CHF&apikey=JIM07LC18T4I2AHC",
                           chartToken = "https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=CHF&apikey=JIM07LC18T4I2AHC"},

        };

        private static Token Token { get; set; }

        public static void Init()
        {
            int index = 0;

            const string metaFile = "alphavantage";
            const string chartFile = "alphavantageMon";
            const string fileType = ".json";

            foreach (var i in tokensAPI)
            {
                bool test;
                try
                {
                    //TODO: finding which files don't exist and download them
                    test = File.Exists(metaFile + index.ToString() + fileType);

                    if (test == false)
                        throw new FileNotFoundException();

                    test = File.Exists(chartFile + index.ToString() + fileType);

                    if (test == false)
                        throw new FileNotFoundException();


                    index++;
                }
                catch (FileNotFoundException e)
                {
                    DownloadScript.Download(i.token, metaFile + index.ToString() + fileType);
                    DownloadScript.Download(i.chartToken, chartFile + index.ToString() + fileType);
                    //Alphavantage api limitation
                    Thread.Sleep(TimeSpan.FromSeconds(30));
                    index++;
                }
            }

            Token token = new Token();
            token.MetaDatas = new List<MetaData>();
            token.ChartModelLists = new List<ChartModelList>();

            MetaData mTemp;
            ChartModelList mChart;
            index = 0;

            foreach (var i in tokensAPI)
            { 
                mTemp = new MetaData();
                mChart = new ChartModelList();
                mChart.ChartModels = new List<ChartModel>();

                JsonReader.Read(metaFile + index.ToString() + fileType, mTemp);
                JsonReader.ChartJsonReader(chartFile + index.ToString() + fileType, mChart.ChartModels);

                index++;

                token.MetaDatas.Add(mTemp);
                token.ChartModelLists.Add(mChart);
            }

            Token = token;
        }

        public static Token GetToken()
        {
            return Token;
        }

    }
}
