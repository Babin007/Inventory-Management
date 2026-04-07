using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models
{
    public class ProductModel
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    }
}