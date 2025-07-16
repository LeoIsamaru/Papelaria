using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papelaria.Shared
{
    public class Supplier
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? SupplierName { get; set; }

        [Required]
        public string? SupplierEmail { get; set; }

        [Required]
        public string? SupplierAddress { get; set; }

        [Required]
        public string? SupplierPhone { get; set; }
    }
}