using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Domain.Entities;
using Persistence;
using Newtonsoft.Json;
using System.IO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    [Route("/currency")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly CurrencyDbContext _context;

        public CurrencyController(CurrencyDbContext context) => _context = context;

        [HttpGet]
        public async Task<Currency[]> GetCurrency()
        {
            return await _context.Currencies.ToArrayAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<Currency> GetCurrencyById(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }
    }
}
