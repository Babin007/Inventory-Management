using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models.Orders
{
    public class CreateOrderModel
    {

        public Guid UserId { get; set; }
        public List<CreateOrderItemModel> Items { get; set; } = new();

    }

}