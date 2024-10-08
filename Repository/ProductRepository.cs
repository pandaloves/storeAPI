using Microsoft.EntityFrameworkCore;
using storeAPI.Data;
using storeAPI.Interfaces;
using storeAPI.Models;

namespace storeAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product, List<IFormFile> files)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Product?> UpdateProduct(int id, Product product, List<IFormFile> files)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productToUpdate == null)
            {
                return null;
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Image = product.Image;
            productToUpdate.Effect = product.Effect;
            productToUpdate.Caffeine = product.Caffeine;
            productToUpdate.Type = product.Type;

        await _context.SaveChangesAsync();
            return productToUpdate;
        }
    }
}