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
        public async Task<ActionResult<DiscountsuppSupplement>> GetDiscountsuppSupplement(string searchTerm, int page = 0, string orderBy = "-discount")
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
                                .Where(x => x.Supplement.Active == true && (x.Brand != null || x.Brand.Id == null) && x.Supplement.Date == date && x.Supplement.Name.ToLower().Contains(searchTerm.ToLower()));

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
                .Where(s => s.Active == true && s.Name.ToLower().Contains(searchTerm.ToLower()) && s.Date == date)
                .Count();

            var totalpages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var json = new MyData { TotalItems = totalItems, TotalPages = totalpages, Items = supplements };

            if (supplements == null)
            {
                return NotFound();
            }

            return Ok(json);
        }      
    }
}
