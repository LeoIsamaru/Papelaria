using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Shared
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        public string? BrandName { get; set; }
    }
}


