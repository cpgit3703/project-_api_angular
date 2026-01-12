using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Reposetorys
{
    public interface IPrizeReposetory
    {
        Task<IEnumerable<Prize>> GetAllPrizesAsync();
        Task<Prize> GetPrizesByIdAsync(int userId);
        Task<Prize> GetPrizesByUserIdAsync(int userId);
        Task<Prize> CreatePrizesAsync(Prize prize);
    }
}
