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


    }
}
