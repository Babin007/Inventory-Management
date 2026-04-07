using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Business.Models;

namespace ECommerce.Business.Interface
{
    public interface IOrderService
    {
        public Task<List<OrderModel>> GetAllAsync();
        public Task<OrderModel> GetByIdAsync();
        public Task<Guid> CreateAsync(OrderModel orderModel, Guid userId);
        public Task UpdateAsync(Guid id, OrderModel orderModel);
        public Task DeleteAsync(Guid id);

    }
}