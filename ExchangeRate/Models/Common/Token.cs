using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Models.Common
{
    public  class Token : IToken
    {
        public IEnumerable<MetaData> MetaDatas => Api.GetMetaData();
        public IEnumerable<ChartModelList> ChartModelLists => Api.GetChartModelLists();
    }
}
