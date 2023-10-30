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
        [HttpGet]
        public async Task<ActionResult<MyData>> GetDiscountsuppSupplement(string url, int page = 1, string orderBy = "-discount")
        {
            int pageSize = 12;

            var date = new DateOnly(2023, 10, 22);

            var brand = await _context.DiscountsuppBrands
                .Where(b => b.BrandUrl.ToLower() == url.ToLower())
                .Select(b => b.Id)
                .FirstOrDefaultAsync();

            var supplementsQuery = _context.DiscountsuppSupplements
                                .GroupJoin(
                                    _context.DiscountsuppBrands,
                                    s => s.BrandId,
                                    b => b.Id,
                                    (s, brands) => new { Supplement = s, Brands = brands })
                                .SelectMany(
                                   x => x.Brands.DefaultIfEmpty(),
                                  (x, brand) => new { Supplement = x.Supplement, Brand = brand })
                                .Where(x => x.Supplement.Active == true && x.Supplement.BrandId == brand); 
            
            if (orderBy == "-discount")
            {
                supplementsQuery = supplementsQuery.OrderByDescending(s => s.Supplement.Discount);
            }
            else if (orderBy == "discount_price")
            {
                supplementsQuery = supplementsQuery.OrderByDescending(s => s.Supplement.DiscountPrice);
            }
            else
            {
                supplementsQuery = supplementsQuery.OrderBy(s => s.Supplement.DiscountPrice);
            }

            var supplements = await supplementsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = _context.DiscountsuppSupplements
                .Where(s => s.Active == true && s.Date == date && s.BrandId == brand)
                .Count();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var json = new MyData { TotalItems = totalItems, TotalPages = totalPages, Items = supplements };

            if (supplements == null)
            {
                return NotFound();
            }

            return Ok(json);
        }  
    }
}
