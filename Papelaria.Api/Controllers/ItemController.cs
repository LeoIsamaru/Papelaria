//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Papelaria.Business.Data;
//using Papelaria.Business.Entities;
//using Papelaria.Shared;
//using SharedBrand = Papelaria.Shared.Brand;
//using SharedCategory = Papelaria.Shared.Category;
//using SharedSupplier = Papelaria.Shared.Supplier;


//namespace Papelaria.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ItemController : ControllerBase
//    {
//        private readonly BusinessContext _businessContext;

//        public ItemController(BusinessContext businessContext)
//        {
//            _businessContext = businessContext;
//        }








//        // GET /items   (Recebe todos os items presentes na base de dados pelo ID)
//        [HttpGet("/items")]
//        public async Task<IActionResult> GetItems()
//        {
//            try
//            {
//                var items = await _businessContext.Items.ToListAsync();

//                // Mapeia para DTO (caso seja necessário)
//                var dtos = items.Select(item => new Papelaria.Shared.Item
//                {
//                    Id = item.Id,
//                    Name = item.Name,
//                    Description = item.Description,
//                    QtyStock = item.QtyStock,
//                    SellingToConsumerPrice = item.SellingToConsumerPrice,
//                    BuyingFromSupplierPrice = item.BuyingFromSupplierPrice
//                }).ToList();

//                return Ok(dtos);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Erro ao obter items: {ex.Message}");
//            }
//        }




//        // GET /items/{id}  (Recebe os items presentes na base de dados pelo ID)
//        [HttpGet("/items/{id}")]
//        public async Task<IActionResult> GetItemById(int id)
//        {
//            var item = await _businessContext.Items.FindAsync(id);
//            if (item == null)
//                return NotFound();

//            var dto = new Papelaria.Shared.Item
//            {
//                Id = item.Id,
//                Name = item.Name,
//                Description = item.Description,
//                QtyStock = item.QtyStock,
//                SellingToConsumerPrice = item.SellingToConsumerPrice,
//                BuyingFromSupplierPrice = item.BuyingFromSupplierPrice
//            };

//            return Ok(dto);
//        }




//        // POST /items  (Cria um novo item na base de dados)
//        [HttpPost("/items")]
//        public async Task<IActionResult> CreateItem([FromBody] Papelaria.Shared.Item newItem)
//        {
//            var entity = new Business.Entities.Item
//            {
//                Name = newItem.Name,
//                Description = newItem.Description,
//                QtyStock = newItem.QtyStock,
//                SellingToConsumerPrice = newItem.SellingToConsumerPrice,
//                BuyingFromSupplierPrice = newItem.BuyingFromSupplierPrice
//            };

//            _businessContext.Items.Add(entity);
//            await _businessContext.SaveChangesAsync();

//            newItem.Id = entity.Id;

//            return CreatedAtAction(nameof(GetItemById), new { id = entity.Id }, newItem);
//        }




//        // PUT /items/{id}/update   (Update Items)
//        [HttpPut("/edit-item/{id}")]
//        public async Task<IActionResult> UpdateItem(int id, [FromBody] Papelaria.Shared.Item updatedItem)
//        {
//            var item = await _businessContext.Items.FindAsync(id);
//            if (item == null)
//                return NotFound();

//            item.Name = updatedItem.Name;
//            item.Description = updatedItem.Description;
//            item.QtyStock = updatedItem.QtyStock;
//            item.SellingToConsumerPrice = updatedItem.SellingToConsumerPrice;
//            item.BuyingFromSupplierPrice = updatedItem.BuyingFromSupplierPrice;
//            item.UpdatedAt = DateTime.UtcNow;

//            await _businessContext.SaveChangesAsync();

//            return NoContent();
//        }




//        // PUT /items/{id}/delete  (Soft delete)
//        [HttpPut("/items/{id}/delete")]
//        public async Task<IActionResult> DeleteItem(int id)
//        {
//            var existingItem = await _businessContext.Items.FindAsync(id);

//            if (existingItem == null || existingItem.IsDeleted)
//            {
//                return NotFound("Item not found.");
//            }

//            existingItem.IsDeleted = true;
//            existingItem.UpdatedAt = DateTime.UtcNow;

//            var result = await _businessContext.SaveChangesAsync(true);

//            if (result > 0)
//                return Ok();
//            else
//                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the item data.");
//        }















//        // GET /items/brands
//        [HttpGet("/items/brands")]
//        public async Task<IActionResult> GetBrands()
//        {
//            var brands = await _businessContext.Brands
//                .Where(b => !b.IsDeleted)
//                .Select(b => new SharedBrand
//                {
//                    Id = b.Id,
//                    BrandName = b.BrandName
//                }).ToListAsync();

//            return Ok(brands);
//        }

//        // GET /items/categories
//        [HttpGet("/items/categories")]
//        public async Task<IActionResult> GetCategories()
//        {
//            var categories = await _businessContext.Categories
//                .Where(c => !c.IsDeleted)
//                .Select(c => new SharedCategory
//                {
//                    Id = c.Id,
//                    CategoryName = c.CategoryName,
//                    CategoryDescription = c.CategoryDescription
//                }).ToListAsync();

//            return Ok(categories);
//        }

//        // GET /items/suppliers
//        [HttpGet("/items/suppliers")]
//        public async Task<IActionResult> GetSuppliers()
//        {
//            var suppliers = await _businessContext.Suppliers
//                .Where(s => !s.IsDeleted)
//                .Select(s => new SharedSupplier
//                {
//                    Id = s.Id,
//                    SupplierName = s.SupplierName,
//                    SupplierEmail = s.SupplierEmail,
//                    SupplierAddress = s.SupplierAddress,
//                    SupplierPhone = s.SupplierPhone
//                }).ToListAsync();

//            return Ok(suppliers);
//        }




//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Papelaria.Shared;
using SharedBrand = Papelaria.Shared.Brand;
using SharedCategory = Papelaria.Shared.Category;
using SharedSupplier = Papelaria.Shared.Supplier;

namespace Papelaria.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public ItemController(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        // GET /items
        [HttpGet("/items")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _businessContext.Items.ToListAsync();

                var dtos = items.Select(item => new Papelaria.Shared.Item
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    QtyStock = item.QtyStock,
                    SellingToConsumerPrice = item.SellingToConsumerPrice,
                    BuyingFromSupplierPrice = item.BuyingFromSupplierPrice
                }).ToList();

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter items: {ex.Message}");
            }
        }

        // GET /items/{id}
        [HttpGet("/items/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _businessContext.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            var dto = new Papelaria.Shared.Item
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                QtyStock = item.QtyStock,
                SellingToConsumerPrice = item.SellingToConsumerPrice,
                BuyingFromSupplierPrice = item.BuyingFromSupplierPrice
            };

            return Ok(dto);
        }

        // POST /items
        [HttpPost("/items")]
        public async Task<IActionResult> CreateItem([FromBody] Papelaria.Shared.Item newItem)
        {

            var brandExists = await _businessContext.Brands.AnyAsync(b => b.Id == newItem.BrandId && !b.IsDeleted);
            var categoryExists = await _businessContext.Categories.AnyAsync(c => c.Id == newItem.CategoryId && !c.IsDeleted);
            var supplierExists = await _businessContext.Suppliers.AnyAsync(s => s.Id == newItem.SupplierId && !s.IsDeleted);

            if (!brandExists)
                return BadRequest($"BrandId {newItem.BrandId} não existe.");
            if (!categoryExists)
                return BadRequest($"CategoryId {newItem.CategoryId} não existe.");
            if (!supplierExists)
                return BadRequest($"SupplierId {newItem.SupplierId} não existe.");


            var entity = new Papelaria.Business.Entities.Item
            {
                Name = newItem.Name,
                Description = newItem.Description,
                QtyStock = newItem.QtyStock,
                SellingToConsumerPrice = newItem.SellingToConsumerPrice,
                BuyingFromSupplierPrice = newItem.BuyingFromSupplierPrice,
                BrandId = (int)newItem.BrandId,          
                CategoryId = (int)newItem.CategoryId,
                SupplierId = (int)newItem.SupplierId
            };

            _businessContext.Items.Add(entity);
            await _businessContext.SaveChangesAsync();

            newItem.Id = entity.Id;

            return CreatedAtAction(nameof(GetItemById), new { id = entity.Id }, newItem);
        }

        // PUT /edit-item/{id}
        [HttpPut("/edit-item/{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Papelaria.Shared.Item updatedItem)
        {
            var item = await _businessContext.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            item.QtyStock = updatedItem.QtyStock;
            item.SellingToConsumerPrice = updatedItem.SellingToConsumerPrice;
            item.BuyingFromSupplierPrice = updatedItem.BuyingFromSupplierPrice;
            item.UpdatedAt = DateTime.UtcNow;

            await _businessContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT /items/{id}/delete (soft delete)
        [HttpPut("/items/{id}/delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existingItem = await _businessContext.Items.FindAsync(id);

            if (existingItem == null || existingItem.IsDeleted)
            {
                return NotFound("Item not found.");
            }

            existingItem.IsDeleted = true;
            existingItem.UpdatedAt = DateTime.UtcNow;

            var result = await _businessContext.SaveChangesAsync(true);

            if (result > 0)
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the item data.");
        }

        // GET /items/brands
        [HttpGet("/items/brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _businessContext.Brands
                .Where(b => !b.IsDeleted)
                .Select(b => new SharedBrand
                {
                    Id = b.Id,
                    BrandName = b.BrandName
                }).ToListAsync();

            return Ok(brands);
        }

        // GET /items/categories
        [HttpGet("/items/categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _businessContext.Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new SharedCategory
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription
                }).ToListAsync();

            return Ok(categories);
        }

        // GET /items/suppliers
        [HttpGet("/items/suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _businessContext.Suppliers
                .Where(s => !s.IsDeleted)
                .Select(s => new SharedSupplier
                {
                    Id = s.Id,
                    SupplierName = s.SupplierName,
                    SupplierEmail = s.SupplierEmail,
                    SupplierAddress = s.SupplierAddress,
                    SupplierPhone = s.SupplierPhone
                }).ToListAsync();

            return Ok(suppliers);
        }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }



    }
}
