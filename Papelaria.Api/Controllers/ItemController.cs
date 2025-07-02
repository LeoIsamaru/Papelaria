using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papelaria.Business;
using System.Collections.Generic;
using System.Data.Entity;
using Papelaria.Shared;

namespace Papelaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IBusinessContext _businessContext;

        public ItemController(IBusinessContext businessContext)
        {
            _businessContext = businessContext;
        }


        [HttpGet("/items")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _businessContext.Items.ToListAsync();

            List<Item> itemList = new List<Item>();

            foreach (var item in items)
            {
                var itemDto = new Item
                {
                    Id=item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    QtyStock = item.QtyStock,
                    SellingToConsumerPrice = item.SellingToConsumerPrice,
                    BuyingFromSupplierPrice = item.BuyingFromSupplierPrice
                };

                itemList.Add(itemDto);

            }

            return Ok(itemList);
        }
    }
}
