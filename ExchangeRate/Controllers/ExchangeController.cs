using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Controllers
{
    public class ExchangeController : Controller
    {
        public ViewResult Exchange(string CurrencyCode)
        {
            return View();
        }

    }
}