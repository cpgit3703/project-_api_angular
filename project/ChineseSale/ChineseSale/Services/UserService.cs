using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ChineseSale.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReposerory _repository;

        public UserService(IUserReposerory repository)
        {
            _repository = repository;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUserAsync()
        {
            var users = await _repository.GetAllUserAsync();
            return users.Select(u => new GetUserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Name = u.Name,
                Phone = u.Phone,
                Address = u.Address,
                Email = u.Email,
                Role = u.Role
            });
        }

        public async Task<GetUserDto?> GetByIdUserAsync(int id)
        {
            var user = await _repository.GetByIdUserAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return new GetUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Phone = user.Phone,
                Address = user.Address,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto dto)
        {
            User duplicate = await _repository.GetByUserNameAsync(dto.UserName);
            if (duplicate != null)
                throw new KeyNotFoundException("UserName already exits ");
            var user = new User
            {
                UserName = dto.UserName,
                Password = HashPassword(dto.Password),
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                Email = dto.Email,
                Role = Role.Customer
            };

            await _repository.CreateUserAsync(user);

            return await GetByIdUserAsync(user.Id);
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _repository.GetByIdUserAsync(dto.Id);
            if (user == null) throw new KeyNotFoundException("User not found");
            User duplicate = await _repository.GetByUserNameAsync(dto.UserName);
            if (duplicate != null)
                throw new KeyNotFoundException("UserName already exits ");

            user.UserName = dto.UserName;
            if (dto.Name != null) user.Name = dto.Name;
            if (dto.Phone != null) user.Phone = dto.Phone;
            if (dto.Address != null) user.Address = dto.Address;
            if (dto.Email != null) user.Email = dto.Email;

           
            await _repository.UpdateUserAsync(user);
            return await GetByIdUserAsync(user.Id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repository.GetByIdUserAsync(id);
            if (user == null) return false;
            await _repository.DeleteUserAsync(user);
      

            return true;
        }

        public async Task<User> LoginAsync(LoginDto dto)
        {
            var user = await _repository.GetByUserNameAsync(dto.UserName);
            if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

            if (user.Password != HashPassword(dto.Password))
                throw new UnauthorizedAccessException("Invalid credentials");

            return user;
        }

    }
}
