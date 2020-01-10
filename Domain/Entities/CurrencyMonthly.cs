using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class CurrencyMonthly
    {
        public int Id { get; }
        public string Published { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        
        [JsonIgnore]
        public Currency Currency { get; set; }
    }
}
