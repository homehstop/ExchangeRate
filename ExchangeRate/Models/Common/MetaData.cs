using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace ExchangeRate.Models.Common
{

    public class MetaData
    {
        [Key]
        public int MetaDataId { get; set; }
        public string Currency { get; set; }
        public string ToCurrency { get; set; }
        public string ExchangeRateString { get; set; }
        public string LastRefreshed { get; set; }
        public string BindPrice { get; set; }
        public string AskPrice { get; set; }
    }
}
