using Almacen.ModelsDTO;

namespace Almacen.Services
{
    public interface ICategoriesService
    {
        Task<List<CategorieDto>> GetAllAsync();
        Task<CategorieDto?> GetByIdAsync(int id);
        Task<CategorieDto> CreateAsync(CreateCategorieDto dto);
        Task<bool> UpdateAsync(int id, UpdateCategorieDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
