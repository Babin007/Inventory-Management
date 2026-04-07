using ECommerce.Data.Entities;
using ECommerce.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(ProductEntity entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductEntity entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}