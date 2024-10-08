using Microsoft.EntityFrameworkCore;
using storeAPI.Data;
using storeAPI.Interfaces;
using storeAPI.Models;

namespace storeAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products) 
                .FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories
                .Include(c => c.Products) 
                .ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                .Include(c => c.Products) 
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateCategory(int id, Category category)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryToUpdate == null)
            {
                return null;
            }
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Image = category.Image;
            await _context.SaveChangesAsync();
            return categoryToUpdate;
        }
    }
}
