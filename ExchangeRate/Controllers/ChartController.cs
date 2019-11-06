using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ExchangeRate.Models;

using Exchange.Private.DataTypes;

namespace ExchangeRate.Controllers
{
    public class ChartController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ChartData()
        { 
            foreach(ExchangeRateData i in ChartDataModel.ChartData.ExchangeRates)
            { 
                return Json(i.ChartModels.ToArray());
            }

            return Json(404);
        }
    }
}