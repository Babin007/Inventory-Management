using ECommerce.Data.Entities;

namespace ECommerce.Data.Interface
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByIdAsync(Guid id);
        Task AddAsync(ProductEntity entity);
        Task UpdateAsync(ProductEntity entity);
        Task DeleteAsync(ProductEntity entity);
    }
}