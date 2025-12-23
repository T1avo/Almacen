using Almacen.Data;
using Almacen.Models;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly AlmacenDbContext _db;

        public CategorieRepository(AlmacenDbContext db)
        {
            _db = db;
        }

        public async Task<Categorie> CreateAsync(Categorie categorie)
        {
            _db.Categories.Add(categorie);
            await _db.SaveChangesAsync();
            return categorie;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (entity is null) return false;

            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<List<Categorie>> GetAllAsync()
        {
            return _db.Categories.OrderBy(c => c.Id).ToListAsync();
        }

        public Task<Categorie?> GetByIdAsync(int id)
        {
            return _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(Categorie categorie)
        {
            var exists = await _db.Categories.AnyAsync(c => c.Id == categorie.Id);
            if (!exists) return false;

            _db.Categories.Update(categorie);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
