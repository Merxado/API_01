using API_01.DAL;
using API_01.DAL.Models;
using API_01.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_01.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            return await _context.Categories.AsNoTracking().AnyAsync(c => c.Id == id);        
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            var exist = await _context.Categories.AsNoTracking().AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            var addedCategory = await _context.Categories.AddAsync(category);

            return await _context.SaveChangesAsync() >= 0 ? true : false;      
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
