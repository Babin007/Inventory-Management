using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Business.Models;
using ECommerce.Data.Entities;

namespace ECommerce.Business.Interface
{
    public interface IProductService
    {
        public Task<List<ProductModel>>GetAllAsync();
        public Task<ProductModel>GetByIdAsync(Guid id);
        public Task<ProductModel>CreateAsync(ProductModel model, Guid categoryId, int? initialStock);
        public Task UpdateAsync(Guid id,ProductModel model);
        public Task DeleteAsync(Guid id);
    }
}