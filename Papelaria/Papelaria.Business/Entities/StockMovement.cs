using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class StockMovement : BaseEntity
    {
        public DateTime Date { get; set; }
        public int? TypeMovementId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }


        //Propriedades Navegação
        public virtual TypeMovement TypeMovement { get; set; }
        public virtual Item Item { get; set; }
    }
}
