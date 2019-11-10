using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Models.Common;
using ExchangeRate.Models;


namespace ExchangeRate.Controllers
{
    public class ExchangeController : Controller
    {
        public IToken repo;
        
        public ExchangeController(IToken token) => repo = token;

        public ViewResult Exchange()
        { 
            return View(repo);
        }
    }
}