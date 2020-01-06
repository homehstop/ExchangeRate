using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Api.JsonObjects
{
    public class CurrencySeries
    {
        public string Refreshed { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
    }
}
