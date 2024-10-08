
namespace storeAPI.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}