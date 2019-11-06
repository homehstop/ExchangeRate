using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Private.DataTypes
{
    public  class Token
    {
        public List<MetaData> MetaDatas { set; get; }
        public List<ChartModelList> ChartModelLists { get; set; }
    }
}
