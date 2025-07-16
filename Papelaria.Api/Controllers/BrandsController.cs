using Microsoft.AspNetCore.Mvc;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class BrandsController : ControllerBase
    {
        private readonly BusinessContext _context;

        public BrandsController(BusinessContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] Brand brand)
        {
            if (brand == null) return BadRequest();

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            return Ok(brands);
        }

    }
}
