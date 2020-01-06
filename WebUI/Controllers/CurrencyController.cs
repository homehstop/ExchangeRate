using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace ExchangeRate.Controllers
{
    public class CurrencyController : Controller
    {
        public ViewResult Index(CurrencyDbContext context)
        {

            return View();
        }
    }
}
