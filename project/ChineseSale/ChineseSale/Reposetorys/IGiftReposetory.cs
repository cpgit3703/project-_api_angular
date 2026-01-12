using ChineseSale.Model;

namespace ChineseSale.Repositories
{
    public interface IGiftReposetory
    {
        Task<IEnumerable<Gift>> GetAllGiftAsync();
        Task<Gift?> GetByIdGiftAsync(int Id);
        Task<Gift> CreateGiftAsync(Gift gift);
        Task<Gift> UpdateGiftAsync(Gift gift);
        Task DeleteGiftAsync(Gift gift);
        Task<IEnumerable<Gift?>> ExistsGiftAsync(string name);
        
    }
}
