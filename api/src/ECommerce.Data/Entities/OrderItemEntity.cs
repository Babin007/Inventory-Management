using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
    public class OrderItemEntity
{
    public Guid Id { get; set; }

    // Foreign Keys
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    // Navigation
    public OrderEntity Order { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
}
}