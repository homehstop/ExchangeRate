using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Models.Common;
using ExchangeRate.Scripts;

namespace ExchangeRate.Controllers
{
    public class ChartController : Controller
    {
        public static List<ChartModel> model; 
        public ViewResult Index(string code)
        {
            var i = SelectItems.Get(Api.GetToken().ChartModelLists, code);
            model = i;

            return View();
        }

        [HttpPost]
        public JsonResult ChartData(string code)
        {
            return Json(model.ToArray());
        }
    }
}