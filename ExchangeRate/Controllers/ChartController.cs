using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Exchange.Private;
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
        public JsonResult ChartData(Token token)
        {
            token = Api.GetToken();

            return Json(token.ChartModelLists.ToArray());
        }
    }
}