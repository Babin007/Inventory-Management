using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models.Orders
{
    public class CreateOrderItemModel
    {

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}