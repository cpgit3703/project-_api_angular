using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ChineseSale.Services;
using ChineseSale.Dto;
using ChineseSale.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IConfiguration config, ILogger<UserController> logger)
        {
            _userService = userService;
            _config = config;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<GetUserDto>> Register(CreateUserDto dto)
        {
            var user = await _userService.CreateUserAsync(dto);
            _logger.LogInformation("Getting All User");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            _logger.LogInformation("Getting All User");
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

       // [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUserAsync()
        {
            return Ok(await _userService.GetAllUserAsync());
            _logger.LogInformation("Getting All User");
        }

       // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetByIdUserAsync(int id)
        {
            //var userId = GetUserIdFromToken();

            //if (userId != id)
            //    return Forbid("You can only access your own profile.");
            var prize = await _userService.GetByIdUserAsync(id);
            _logger.LogInformation("Getting All User");
            return Ok(prize);
            //return Ok(await _userService.GetByIdUserAsync(id));
        }

        //[Authorize]
        [HttpPut]
        public async Task<ActionResult<GetUserDto>> UpdateUserAsync(UpdateUserDto dto)
        {
            return Ok(await _userService.UpdateUserAsync(dto));
            _logger.LogInformation("Getting All User");
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            _logger.LogInformation("Getting All User");
            return tokenHandler.WriteToken(token);
        }

        //private int GetUserIdFromToken()
        //{
        //    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
        //    if (userIdClaim == null)
        //        throw new UnauthorizedAccessException("User ID claim missing");

        //    return int.Parse(userIdClaim.Value);
        //}
      
    }
}
