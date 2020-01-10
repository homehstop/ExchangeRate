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
using MediatR;

namespace WebUI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly CurrencyDbContext _context;

        public CurrencyController(CurrencyDbContext context) => _context = context;

        [HttpGet]
        public string Currency()
        {
           return "Hello world";
        }
        
        [HttpGet("{id}")]
        public Currency CurrencyById(int id)
        {
            return _context.Currencies.Find(id);
        }
    }
}
