using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class Brand : BaseEntity
    {

        public string? BrandName { get; set; }



        //Propriedades Navegação
        public virtual ICollection<Item> Items { get; set; }
    }
}
