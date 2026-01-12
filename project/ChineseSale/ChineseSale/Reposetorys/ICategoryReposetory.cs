using ChineseSale.Model;

namespace ChineseSale.Repositories
{
    public interface ICategoryReposetory
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category?>GetByIdCategoryAsync(int Id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<Category?> AddGitfToCategory(Gift gift,Category category);
        Task<Category?> DeleteGitFromCategory(Gift gift,Category category);


    }
}
