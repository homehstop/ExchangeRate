using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Private.DataTypes
{
    public class ChartModel
    {
        public string Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
    }
}
