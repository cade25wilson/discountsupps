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
    public class BrandController : ControllerBase
    {
        private readonly SuppContext _context;

        public BrandController(SuppContext context)
        {
            _context = context;
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetDiscountsuppSupplement(long id, int page = 1)
        {
            int pageSize = 12;

            var brand = await _context.DiscountsuppBrands
                .Where(b => b.Id == id)
                .Select(b => b.BrandName)
                .FirstOrDefaultAsync();

            if (brand == null)
            {
                return NotFound();
            }

            var supplements = await _context.DiscountsuppSupplements
                .Where(s => s.BrandId == id && s.Active == true)
                .Skip((page - 1) * pageSize)
                .OrderBy(s => s.Name)
                .Take(pageSize)
                .ToListAsync();

            if (supplements == null)
            {
                return NotFound();
            }

            var json = new
            {
                brand,
                supplements
            };  

            return json;
        }  
    }
}
