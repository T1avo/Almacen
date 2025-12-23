using Almacen.Models;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
    public class AlmacenDbContext : DbContext
    {
        public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options): base(options){ }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }

    }
}
