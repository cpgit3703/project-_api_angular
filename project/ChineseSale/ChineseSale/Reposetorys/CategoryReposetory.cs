using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;


namespace ChineseSale.Repositories
{
    public class CategoryReposetory : ICategoryReposetory
    {
        private readonly ChineseSaleDbContext _context;

        public CategoryReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categorys
                .Include(c => c.Gifts)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdCategoryAsync(int Id)
        {
                   return await _context.Categorys
                   .Include(c => c.Gifts)
                   .ThenInclude(d => d.Donor)
                  .FirstOrDefaultAsync(g => g.Id == Id);

        }
        public async Task<Category?> AddGitfToCategory(Gift gift,Category category)
        {
          
            category.Gifts.Add(gift);
            _context.Categorys.Update(category);
            await _context.SaveChangesAsync();
            return category;

        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _context.Categorys.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categorys.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteGitFromCategory(Gift gift,Category category)
        {
            category.Gifts.Remove(gift);    
            _context.Categorys.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
