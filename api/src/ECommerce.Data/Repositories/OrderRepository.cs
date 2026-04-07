using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Data.Entities;
using ECommerce.Data.Interface;

namespace ECommerce.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }
    }
}