namespace Almacen.ModelsDTO
{
    public class UpdateCategorieDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
