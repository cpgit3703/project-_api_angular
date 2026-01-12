using ChineseSale.Dto;
using ChineseSale.Model;
namespace ChineseSale.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<GetBasketDto>> GetAllBasketAsync();
        Task<GetByUserBasketDto?> GetByIdBasketAsync(int Id);
        Task<GetBasketDto> CreateBasketAsync(CreateBasketDto createBasketDto);
        Task<GetByUserBasketDto?> AddGiftsToBasketAsync(AddGiftsToBasketDto addGiftsToBasketDto);
        Task<GetByUserBasketDto?> DeleteGiftsFromBasketAsync(DeleteGiftsFromBasketDto addGiftsToBasketDto);
        Task<bool> DeleteBasketAsync(int id);
    }
}
