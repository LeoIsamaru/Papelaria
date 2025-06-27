using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class Item : BaseEntity
    {
        // Propriedades diretas do Produto
        public string Name { get; set; }

        public string Description { get; set; }

        public int QtyStock { get; set; }

        public float SellingToConsumerPrice { get; set; }

        public float BuyingFromSupplierPrice { get; set; }


        // Chaves estrangeiras (FK's)
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }


        //Propriedades Navegação

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<StockMovement> StockMovements { get; set; }
        public virtual ICollection<Image> Images { get; set; }



    }
}





