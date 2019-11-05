using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Exchange.Private;
using Exchange.Private.DataTypes;

namespace ExchangeRate.Controllers
{
    public class ExchangeController : Controller
    {
        Api Api = new Api();

        public ViewResult Exchange(ExchangeDataList exchangeDataList)
        {
            exchangeDataList = new ExchangeDataList();

            exchangeDataList =  Api.Init();

            return View(exchangeDataList);
        }
    }
}