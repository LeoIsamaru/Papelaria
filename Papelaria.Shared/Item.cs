using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Shared
{
    public class Item
    {

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int QtyStock { get; set; }

        [Required]
        public decimal SellingToConsumerPrice { get; set; }

        [Required]
        public decimal BuyingFromSupplierPrice { get; set; }



        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }


        // Campos de leitura
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }


        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Soft delete
        public bool IsDeleted { get; set; }
    }
}
