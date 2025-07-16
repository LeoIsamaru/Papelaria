using Microsoft.AspNetCore.Mvc;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class BrandsController : ControllerBase
    {
        private readonly BusinessContext _context;

        public BrandsController(BusinessContext context)
        {
            _context = context;
        }

        [HttpPost("/brands")]
        public async Task<IActionResult> AddBrand([FromBody] Papelaria.Shared.Brand brand)
        {
            if (brand == null) return BadRequest();

            var newBrand = new Brand
            {
                BrandName = brand.BrandName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Items = new List<Item>()
            };

            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }


        [HttpGet("/brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            return Ok(brands);
        }

    }
}
