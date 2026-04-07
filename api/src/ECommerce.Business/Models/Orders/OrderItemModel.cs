using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models
{

    public class OrderItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

}