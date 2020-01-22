using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebUI.Controllers
{
    [Route("/monthly")]
    [ApiController]
    public class CurrencyMonthlyController : Controller
    {
        private readonly CurrencyDbContext _context;

        public CurrencyMonthlyController(CurrencyDbContext context) => _context = context;

        [HttpGet]
        public string GetCurrencyMonthly()
        {
            return "The api request must contain currency id";
        }

        [HttpGet("{id}")]
        public async Task<CurrencyMonthly[]> GetCurrencyMonthlyById(int id)
        {
            return await _context.CurrencyMonthlies
                .Where(x => x.Id == id)
                .ToArrayAsync();
        }
    }
}
