using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class Category : BaseEntity
    {

        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }



        //Propriedades Navegação
        public virtual ICollection<Item> Items { get; set; }
    }
}
