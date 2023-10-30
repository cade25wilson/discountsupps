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
        public async Task<ActionResult<DiscountsuppSupplement>> GetDiscountsuppSupplements(int page = 1, string orderBy = "-discount")
        {
            int pageSize = 12;
            DateOnly? date = new DateOnly(2023, 10, 22);

            var supplementsQuery = _context.DiscountsuppSupplements
                                .GroupJoin(
                                    _context.DiscountsuppBrands,
                                    s => s.BrandId,
                                    b => b.Id,
                                    (s, brands) => new { Supplement = s, Brands = brands })
                                .SelectMany(
                                    x => x.Brands.DefaultIfEmpty(),
                                    (x, brand) => new { Supplement = x.Supplement, Brand = brand })
                                .Where(x => x.Supplement.Active == true && (x.Brand != null || x.Brand.Id == null) && x.Supplement.Date == date);

            if(orderBy == "-discount")
            {
                supplementsQuery = supplementsQuery.OrderByDescending(s => s.Supplement.Discount);
            }
            else if(orderBy == "discount_price")
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
                .Where(s => s.Active == true && s.Date == date)
                .Count();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var json = new MyData { TotalItems = totalItems, TotalPages = totalPages, Items = supplements };

            return Ok(json);
        }
    }
}
