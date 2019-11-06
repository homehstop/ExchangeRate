using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Private.DataTypes
{
    public class ChartModelList
    {
        public List<ChartModel> ChartModels { get; set; }
    }

    public class ChartModel
    {
        public float Open { get; set; }
        public string Date { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
    }
}
