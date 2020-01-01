using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Monthly
    {
        public int MonthlyId { get; set; }
        public string Published { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public CurrencyMonthly CurrencyMonthly { get; set; }
    }
}
