using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Models
{

    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }

}