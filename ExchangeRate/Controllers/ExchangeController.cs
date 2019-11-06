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
        public ViewResult Exchange(Token token)
        {
            Api.Init();

            token = Api.GetToken();

            return View(token);
        }
    }
}