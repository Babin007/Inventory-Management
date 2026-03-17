using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
    public class OrderEntity
{
    public Guid Id { get; set; }

    // Foreign Key
    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // Navigation
    public UserEntity User { get; set; } = null!;
    public ICollection<OrderItemEntity> Items { get; set; }
        = new List<OrderItemEntity>();
}
}