using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Models.Common
{
    public  class Token
    {

        //TODO: interfaces 
        public List<MetaData> MetaDatas { set; get; }
        public List<ChartModelList> ChartModelLists { get; set; }
    }
}
