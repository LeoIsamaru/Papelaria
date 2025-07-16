using Microsoft.AspNetCore.Mvc;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly BusinessContext _context;

        public CategoriesController(BusinessContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null) return BadRequest();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }




        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

    }
}
