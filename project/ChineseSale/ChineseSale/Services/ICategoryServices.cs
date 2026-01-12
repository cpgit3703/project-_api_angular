using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<GetCategoryDto>> GetAllCategoryAsync();
        Task<GetCategoryByIdDto?> GetByIdCategoryAsync(int Id);
        Task<GetCategoryDto> CreateCategoryAsync(CreateCategoryDto CategoryDto);
        Task<GetCategoryByIdDto> UpdateCategoryAsync(UpdateCategoryDto CategoryDto);
        Task<bool> DeleteCategoryAsync(int id);


    }
}
