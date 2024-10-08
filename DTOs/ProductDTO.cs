
namespace storeAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Effect { get; set; }
        public string? Caffeine { get; set; }
        public string? Type { get; set; }
        public int CategoryId { get; set; }  
       
    }
}