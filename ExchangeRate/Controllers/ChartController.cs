using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Models.Common;

namespace ExchangeRate.Controllers
{
    public class ChartController : Controller
    {
        public static List<ChartModel> model; 
        public ViewResult Index(string code)
        {
            var i = Api.GetToken().ChartModelLists.ToArray();

            List<ChartModel> modelList = new List<ChartModel>(); ;
            foreach (var p in i)
            {
                foreach (var l in p.ChartModels)
                {
                    if (l.Name == code)
                    {
                        modelList.Add(l);
                    }
                    else
                    { break; }
                }
            }

            model = modelList;

            return View();
        }

        [HttpPost]
        public JsonResult ChartData(string code)
        {
            return Json(model.ToArray());
        }
    }
}