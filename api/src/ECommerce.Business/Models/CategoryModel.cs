using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models
{
    public class CategoryModel
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    }
}