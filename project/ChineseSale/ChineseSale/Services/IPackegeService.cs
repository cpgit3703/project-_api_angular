using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Services
{
    public interface IPackegeService
    {
        Task<IEnumerable<GetPackageDto>> GetAllPackageAsync();
        Task<GetPackageDto?> GetByIdPackageAsync(int Id);
        Task<GetPackageDto> CreatePackageAsync(CreatePackageDto createPackageDto);
        Task<GetPackageDto> UpdatePackageAsync(UpdatePackageDto updatePackageDto);
        Task<bool> DeletePackageAsync(int id);
    }
}
