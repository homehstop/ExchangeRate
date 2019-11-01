using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Exchange.Private.DataTypes
{

    public class ExchangeRate
    {
        public string From { get; set; }
        public string To { get; set; }
        public string ExchangeRateString { get; set; }
        public string LastRefreshed { get; set; }
        public string BindPrice { get; set; }
        public string AskPrice { get; set; }
    }
}
