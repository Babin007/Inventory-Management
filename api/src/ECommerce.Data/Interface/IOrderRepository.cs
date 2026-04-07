using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Data.Entities;

namespace ECommerce.Data.Interface
{
    public interface IOrderRepository
    {

        Task AddAsync(OrderEntity order);

    }
}