using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRate.Models.Common;

namespace ExchangeRate.Scripts
{
    public class SelectItems
    {
        public static List<ChartModel> Get(List<ChartModelList> chartModelLists, string code)
        {
            List<ChartModel> modelList = new List<ChartModel>();

            foreach (var i in chartModelLists)
            {
                foreach (var z in i.ChartModels)
                {
                    if (z.Name == code)
                    {
                        modelList.Add(z);
                    }
                    else
                    { break; }
                }
            }

            return modelList.OrderBy(x => x.Date).ToList();
        }
    }
}
