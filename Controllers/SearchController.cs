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
    public class SearchController : ControllerBase
    {
        private readonly SuppContext _context;

        public SearchController(SuppContext context)
        {
            _context = context;
        }

        // GET: api/Search
        [HttpGet]
        public async Task<ActionResult<DiscountsuppSupplement>> GetDiscountsuppSupplement(string searchTerm, int page = 0)
        {
            int pageSize = 12;

            var supplements = await _context.DiscountsuppSupplements
                .Where(s => s.Active == true && s.Name.ToLower().Contains(searchTerm.ToLower()))
                .Skip((page - 1) * pageSize)
                .OrderBy(s => s.Name)
                .Take(pageSize)
                .ToListAsync();

            if (supplements == null)
            {
                return NotFound();
            }

            return Ok(supplements);
        }

       
    }
}
