using ChineseSale.Dto;
using ChineseSale.Model;
namespace ChineseSale.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<GetBasketDto>> GetAllBasketAsync();
        Task<GetByUserBasketDto?> GetByIdBasketAsync(int Id);

        Task<GetByUserBasketDto?> GetBasketByUserIdAsync(int Id);
        Task<GetBasketDto> CreateBasketAsync(CreateBasketDto createBasketDto);
        Task<GetByUserBasketDto?> AddGiftsToBasketAsync(AddGiftsToBasketDto addGiftsToBasketDto);
        Task<GetByUserBasketDto?> DeleteGiftsFromBasketAsync(DeleteGiftsFromBasketDto addGiftsToBasketDto);
        Task<GetByUserBasketDto?> AddPackagesToBasketAsync(AddPackagesToBasketDto addPackagesToBasketDto);
        Task<GetByUserBasketDto?> DeletePackagesFromBasketAsync(DeletePackagesFromBasketDto deletePackagesFromBasketDto);
        Task<bool> DeleteBasketAsync(int id);
    }
}
