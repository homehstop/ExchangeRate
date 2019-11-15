using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Models.Common;
using ExchangeRate.Scripts;
using ExchangeRate.Models;

namespace ExchangeRate.Controllers
{
    public class ChartController : Controller
    {
        private IToken repo;
        private static List<ChartModel> temp;

        public ChartController(IToken token) => repo = token;

        public ViewResult Index(string code)
        {

            //var i = SelectItems.Get(repo.ChartModelLists, code);
            //
            //temp = i;

            return View();
        }

        [HttpPost]
        public JsonResult ChartData()
        {
            return Json(temp.ToArray());
        }
    }
}