using Almacen.Models;
using Almacen.ModelsDTO;
using Almacen.Repositories;

namespace Almacen.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategorieRepository _repo;  
        public CategoriesService(ICategorieRepository repo)
        {
            _repo = repo;
        }
        public async Task<CategorieDto> CreateAsync(CreateCategorieDto dto)
        {
            var entity = new Categorie
            {
                Name = dto.Name.Trim(),
                Description = dto.Description,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repo.CreateAsync(entity);

            return new CategorieDto
            {
                Id = created.Id,
                Name = created.Name,
                Description = created.Description,
                IsActive = created.IsActive
            };
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task<List<CategorieDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();

            return items.Select(c => new CategorieDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive
            }).ToList();
        }

        public async Task<CategorieDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c is null) return null;

            return new CategorieDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategorieDto dto)
        {
            var current = await _repo.GetByIdAsync(id);
            if (current is null) return false;

            current.Name = dto.Name.Trim();
            current.Description = dto.Description;
            current.IsActive = dto.IsActive;

            return await _repo.UpdateAsync(current);
        }
    }
}
