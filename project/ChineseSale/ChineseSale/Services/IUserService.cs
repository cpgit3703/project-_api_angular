using ChineseSale.Dto;
using ChineseSale.Model;

namespace ChineseSale.Services
{
    public interface IUserService
    {
            Task<IEnumerable<GetUserDto>> GetAllUserAsync();
            Task<GetUserDto?> GetByIdUserAsync(int Id);
            Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
            Task<GetUserDto> UpdateUserAsync(UpdateUserDto userDto);
            Task<bool> DeleteUserAsync(int id);
            Task<User> LoginAsync(LoginDto dto);



    }
}
