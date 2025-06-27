using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Business.Entities
{
    public class Image : BaseEntity
    {
        public int? ItemId { get; set; }
        public string? URL { get; set; }



        //Propriedades Navegação
        public virtual Item Item { get; set; }
    }

}
