using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Exchange.Private.DataTypes
{
    public class ExchangeDataList
    {
        public IList<ExchangeRateData> ExchangeRates { set; get; }
    }
}
