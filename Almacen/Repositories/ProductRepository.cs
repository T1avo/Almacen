using Almacen.Data;
using Almacen.Models;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AlmacenDbContext _db;

        public ProductRepository(AlmacenDbContext db)
        {
            _db = db;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _db.Products.OrderBy(p => p.Id).ToListAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var exists = await _db.Products.AnyAsync(p => p.Id == product.Id);
            if (!exists) return false;

            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (entity is null) return false;

            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
