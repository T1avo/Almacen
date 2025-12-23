using Almacen.Models;
using Almacen.ModelsDTO;
using Almacen.Repositories;

namespace Almacen.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();

            return items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p is null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            };
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var entity = new Product
            {
                Name = dto.Name.Trim(),
                Price = dto.Price,
                Stock = dto.Stock,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repo.CreateAsync(entity);

            return new ProductDto
            {
                Id = created.Id,
                Name = created.Name,
                Price = created.Price,
                Stock = created.Stock
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var current = await _repo.GetByIdAsync(id);
            if (current is null) return false;

            current.Name = dto.Name.Trim();
            current.Price = dto.Price;
            current.Stock = dto.Stock;

            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
