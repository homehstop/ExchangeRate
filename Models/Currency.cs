using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExchangeRate.Models
{
    public class Currency 
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        [ForeignKey("ToCurrency")]
        public List<ToCurrency> ToCurrencies { get; set; }
    }

    public class ToCurrency
    { 
        public int ToCurrencyId { get; set; }
        public string ToCurrencyName { get; set; }
        public float ExchangeRate { get; set; }
        public float BidPrice { get; set; }
        public float AskPrice { get; set; }
        public string LastRefreshed { get; set; }

        [ForeignKey("Currency")]
        public List<CurrencyMonthly> CurrencyMonthlies { get; set; }
    }

    public class CurrencyMonthly
    {
        public int CurrencyMonthlyId { get; set; }
        public string LastRefreshed { get; set; }

        [ForeignKey("ToCurrency")]
        public List<Monthly> Monthlies { get; set; }
    }

    public class Monthly
    {
        [ForeignKey("CurrencyMonthly")]
        public int MonthlyId { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
    }
}
