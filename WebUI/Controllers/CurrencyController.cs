using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Persistence;
using Newtonsoft.Json;
using System.IO;

namespace WebUI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly CurrencyDbContext context;

        public CurrencyController(CurrencyDbContext context) => this.context = context;

        [HttpGet]
        public IEnumerable<Currency> Currency()
        {
            return context.Currencies.ToArray();
        }

        [HttpGet("{id}")]
        public Currency CurrencyById(int id)
        {
            var foo = context.Currencies.Find(id);

            return foo;
        }
    }
}
