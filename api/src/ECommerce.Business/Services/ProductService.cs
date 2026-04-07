using ECommerce.Business.Exceptions;
using ECommerce.Business.Interface;
using ECommerce.Business.Models;
using ECommerce.Data.Entities;
using ECommerce.Data.Interface;

namespace ECommerce.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    // ✅ GET ALL PRODUCTS
    public async Task<List<ProductModel>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return entities.Select(e => new ProductModel
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price
        }).ToList();
    }

    // ✅ GET PRODUCT BY ID
    public async Task<ProductModel> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            throw new NotFoundException($"Product with id '{id}' not found");

        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };
    }

    // ✅ CREATE PRODUCT (USING YOUR EXACT LOGIC)
    public async Task<ProductModel> CreateAsync(
        ProductModel model,
        Guid categoryId,
        int? initialStock)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            throw new BadRequestException("Product name is required");

        if (model.Price <= 0)
            throw new BadRequestException("Price must be greater than zero");

        if (initialStock < 0)
            throw new BadRequestException("Stock cannot be negative");

        var entity = new ProductEntity
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Price = model.Price,
            Stock = initialStock ?? 0,
            CategoryId = categoryId
        };

        await _repository.AddAsync(entity);
        model.Id = entity.Id;
        return model;
    }

    // ✅ UPDATE PRODUCT
    public async Task UpdateAsync(Guid id, ProductModel model)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            throw new NotFoundException($"Product with id '{id}' not found");

        if (string.IsNullOrWhiteSpace(model.Name))
            throw new BadRequestException("Product name is required");

        if (model.Price <= 0)
            throw new BadRequestException("Price must be greater than zero");

        entity.Name = model.Name;
        entity.Price = model.Price;

        await _repository.UpdateAsync(entity);
    }

    // ✅ DELETE PRODUCT
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            throw new NotFoundException($"Product with id '{id}' not found");

        await _repository.DeleteAsync(entity);
    }

}