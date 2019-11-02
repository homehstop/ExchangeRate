using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Exchange.Private.DataTypes;

namespace ExchangeRate.Models
{
    public class ChartDataModel
    {
        public static List<ChartModel> GetChartDataModels()
        {
            var list = new List<ChartModel>() {
                new ChartModel { Code = "USD", Year0 = 100, Year1 = 200, Year2 = 300 },
                new ChartModel { Code = "UAH", Year0 = 50, Year1 = 200, Year2 = 40 },
                new ChartModel { Code = "CHF", Year0 = 1000, Year1 = 350, Year2 = 600 
            }};

            return list;
        }
    }
}
