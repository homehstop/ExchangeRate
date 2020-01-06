using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CurrencyMonthly
    {
        public int CurrencyMonthlyId { get; set; }
        public string LastRefreshed { get; set; }
        public ICollection<Currency> Currency { get; set; }
        public ICollection<Monthly> Monthly { get; set; }
    }
}
