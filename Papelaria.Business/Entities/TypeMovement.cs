using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class TypeMovement : BaseEntity
    {
        public string? Name { get; set; }



        //Propriedades Navegação

        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }

}
