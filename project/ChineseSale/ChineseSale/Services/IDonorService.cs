using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Services
{
    public interface IDonorService
    {
        Task<IEnumerable<GetDonorDto>> GetAllDonorAsync();
        Task<GetByIdDonorDto?> GetByIdDonorDtoAsync(int Id);
        Task<GetDonorDto> CreateDonorAsync(CreateDonorDto createDonorDto);
        Task<GetByIdDonorDto> UpdateDonorAsync(UpdateDonorDto updateDonorDto);
        Task<bool> DeleteDonorAsync(int id);
        Task<IEnumerable<GetDonorDto?>> ExistsDonorAsync(string name);
        Task<IEnumerable<GetDonorDto?>> ExistsDonorEmailAsync(string email);
        Task<IEnumerable<GetDonorDto?>> ExistsDonorAsync(Gift gift);


    }
}
