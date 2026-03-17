using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
    public class CategoryEntity
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    // Navigation
    public ICollection<ProductEntity> Products { get; set; }= new List<ProductEntity>();
    // We use ICollection because we want to Add/Remove books and see how many we have.
    }
}