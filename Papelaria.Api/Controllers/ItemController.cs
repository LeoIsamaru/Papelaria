using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papelaria.Business.Data;
using Papelaria.Business.Entities;
using Papelaria.Shared;
using SharedItem = Papelaria.Shared.Item;
using EntityItem = Papelaria.Business.Entities.Item;


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



        // GET /items   (Recebe todos os items presentes na base de dados pelo ID)
        [HttpGet("/items")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _businessContext.Items.ToListAsync();

                // Mapeia para DTO (caso seja necessário)
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




        // GET /items/{id}  (Recebe os items presentes na base de dados pelo ID)
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




        // POST /items  (Cria um novo item na base de dados)
        [HttpPost("/items")]
        public async Task<IActionResult> CreateItem([FromBody] SharedItem newItem)
        {
            var entity = new EntityItem
            {
                Name = newItem.Name,
                Description = newItem.Description,
                QtyStock = newItem.QtyStock,
                SellingToConsumerPrice = newItem.SellingToConsumerPrice,
                BuyingFromSupplierPrice = newItem.BuyingFromSupplierPrice
            };

            _businessContext.Items.Add(entity);
            await _businessContext.SaveChangesAsync();

            newItem.Id = entity.Id;

            return CreatedAtAction(nameof(GetItemById), new { id = entity.Id }, newItem);
        }




        // PUT /items/{id}/update   (Update Items)
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




        // PUT /items/{id}/delete  (Soft delete)
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

    }
}
