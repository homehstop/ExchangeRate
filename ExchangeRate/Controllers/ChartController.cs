using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ExchangeRate.Models;

namespace ExchangeRate.Controllers
{
    public class ChartController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ChartData()
        {
            var ChartDatas = ChartDataModel.GetChartDataModels();
            return Json(ChartDatas);
        }

    }
}