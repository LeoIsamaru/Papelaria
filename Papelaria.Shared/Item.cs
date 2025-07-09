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
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int QtyStock { get; set; }

        [Required]
        public float SellingToConsumerPrice { get; set; }

        [Required]
        public float BuyingFromSupplierPrice { get; set; }


    }
}
