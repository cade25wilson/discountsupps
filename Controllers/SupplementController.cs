using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supps.Data;
using supps.Models;

namespace supps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplementController : ControllerBase
    {
        private readonly SuppContext _context;

        public SupplementController(SuppContext context)
        {
            _context = context;
        }

        // GET: api/Supplement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountsuppSupplement>>> GetDiscountsuppSupplements(int page = 1)
        {
            int pageSize = 12;
            DateOnly? date = new DateOnly(2023, 10, 22);

            var supplements = await _context.DiscountsuppSupplements
                .Where(s => s.Active == true && s.Date == date) 
                .Skip((page - 1) * pageSize)
                .OrderBy(s => s.Name)
                .Take(pageSize)
                .ToListAsync();

            if (supplements == null)
            {
                return NotFound();
            }

            return supplements;
        }
    }
}
