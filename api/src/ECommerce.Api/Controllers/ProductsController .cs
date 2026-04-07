using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.DTOs.Products;
using ECommerce.Business.Interface;
using ECommerce.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(_mapper.Map<ProductResponseDto>(model));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _service.GetAllAsync();
            if (model == null || model.Count == 0)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<ProductResponseDto>>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestDto request)
        {
            var model = _mapper.Map<ProductModel>(request);

            var created = await _service.CreateAsync(
                model,
                request.CategoryId,
                initialStock: 0);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                _mapper.Map<ProductResponseDto>(created));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, CreateProductRequestDto request)
        {
            var existingProduct = await _service.GetByIdAsync(id);
            if (existingProduct == null) return NotFound();

            var model = _mapper.Map<ProductModel>(request);
            await _service.UpdateAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingProduct = await _service.GetByIdAsync(id);
            if (existingProduct == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}