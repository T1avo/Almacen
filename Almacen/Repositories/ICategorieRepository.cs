using Almacen.Models;

namespace Almacen.Repositories
{
    public interface ICategorieRepository
    {
        Task<List<Categorie>> GetAllAsync();
        Task<Categorie?> GetByIdAsync(int id);
        Task<Categorie> CreateAsync(Categorie categorie);
        Task<bool> UpdateAsync(Categorie categorie);
        Task<bool> DeleteAsync(int id);
    }
}
