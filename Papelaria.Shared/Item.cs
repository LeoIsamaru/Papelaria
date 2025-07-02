using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Shared
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int QtyStock { get; set; }

        public float SellingToConsumerPrice { get; set; }

        public float BuyingFromSupplierPrice { get; set; }


    }
}
