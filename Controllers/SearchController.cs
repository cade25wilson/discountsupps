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
                .Where(s => s.Active == true && s.Name.ToLower().Contains(searchTerm.ToLower()) && s.Date == date);

            if (orderBy == "-discount")
            {
                supplementsQuery = supplementsQuery.OrderByDescending(s => s.Discount);
            }
            else if (orderBy == "discount_price")
            {
                supplementsQuery = supplementsQuery.OrderByDescending(s => s.DiscountPrice);
            }
            else
            {
                supplementsQuery = supplementsQuery.OrderBy(s => s.DiscountPrice);
            }

            var supplements = await supplementsQuery
                .Skip((page - 1) * pageSize)
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
