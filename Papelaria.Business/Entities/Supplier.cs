using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class Supplier : BaseEntity
    {

        public string? SupplierName { get; set; }

        public string? SupplierEmail { get; set; }

        public string? SupplierAddress { get; set; }

        public string? SupplierPhone { get; set; }


        //Propriedades Navegação
        public virtual ICollection<Item> Items { get; set; }
    }
}
