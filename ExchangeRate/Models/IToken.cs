using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRate.Models.Common;

namespace ExchangeRate.Models
{
    public interface IToken
    {
         IEnumerable<MetaData> MetaDatas { get; }
         IEnumerable<ChartModelList> ChartModelLists { get; }
    }
}
