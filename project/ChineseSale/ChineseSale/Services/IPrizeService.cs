using ChineseSale.Dto;
using ChineseSale.Model;
namespace ChineseSale.Services
{
    public interface IPrizeService
    {
        Task<IEnumerable<GetPrizeDto>> GetAllPrizesAsync();
        Task<GetPrizeDto> GetPrizesByIdAsync(int userId);
        Task<GetPrizeDto> GetPrizesByUserIdAsync(int userId);
        Task<GetPrizeDto> CreatePrizesAsync(CreatePrizeDto createPrizeDto);
        Task<GetPrizeDto> SelectRandomPrize(int giftId);
        public Task<GetPrizeDto?> PickWinnerAndSendEmailAsync(int giftId);
    }
}
