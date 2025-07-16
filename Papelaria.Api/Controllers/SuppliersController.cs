using Microsoft.AspNetCore.Mvc;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly BusinessContext _context;

        public SuppliersController(BusinessContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null) return BadRequest();

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return Ok(suppliers);
        }

    }
}
