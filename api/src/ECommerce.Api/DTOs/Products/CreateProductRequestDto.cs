using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.DTOs.Products
{
    public class CreateProductRequestDto
    {

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        [Range(0.01, 1_000_000)]
        public int Price { get; set; }
        public int? InitialStock { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

    }
}