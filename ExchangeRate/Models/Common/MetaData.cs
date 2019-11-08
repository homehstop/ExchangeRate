using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace ExchangeRate.Models.Common
{

    public class MetaData
    {
        public string From { get; set; }
        public string To { get; set; }
        public string ExchangeRateString { get; set; }
        public string LastRefreshed { get; set; }
        public string BindPrice { get; set; }
        public string AskPrice { get; set; }
    }
}
