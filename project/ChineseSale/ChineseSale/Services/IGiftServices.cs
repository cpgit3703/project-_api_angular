using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Services
{
    public interface IGiftServices
    {
        Task <IEnumerable<GetGiftDto> >GetAllGiftAsync();
        Task<GetGiftDto?> GetByIdGiftAsync(int Id); 
        Task<GetGiftDto> CreateGiftDtoAsync(CreateGiftDto GiftDto);
        Task<GetGiftDto> UpdateGiftAsync(UpdateGiftDto updateGiftDto);
        Task<bool> DeleteGiftAsync(int id);
        Task<IEnumerable<GetGiftDto?>> ExistsGiftAsync(string name);
        Task<IEnumerable<GetGiftDto?>> ExistsGiftDonorAsync(int donor);
        Task<IEnumerable<GetGiftDto?>> ExistsGiftAsync(int sumCustomers);
       


    }
}
