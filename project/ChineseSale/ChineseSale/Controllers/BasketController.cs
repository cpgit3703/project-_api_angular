using ChineseSale.Dto;
using ChineseSale.Services;
using Microsoft.AspNetCore.Mvc;
namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketServices;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IBasketService basketServices, ILogger<BasketController> logger)
        {
            _basketServices = basketServices;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBasketDto>>> GetAllBasketAsync()
        {
            var baskets = await _basketServices.GetAllBasketAsync();
            _logger.LogInformation("Getting All Gift");
            return Ok(baskets);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetByUserBasketDto>> GetByIdBasketAsync(int Id)
        {
            try
            {
                var basket = await _basketServices.GetByIdBasketAsync(Id);
                _logger.LogInformation("Getting All Gift");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<GetByUserBasketDto>> GetByUserIdBasketAsync(int userId)
        {
            try
            {
                var basket = await _basketServices.GetBasketByUserIdAsync(userId);
                _logger.LogInformation("Getting All Gift");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]

        public async Task<ActionResult<GetBasketDto>> CreateBasketAsync(CreateBasketDto basketDto)
        {
            try
            {
                var basket = await _basketServices.CreateBasketAsync(basketDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost("AddGift")]
        public async Task<ActionResult<GetByUserBasketDto>> AddGiftsToBasketDto(AddGiftsToBasketDto addGiftsToBasketDto)
        {

            try
            {
                var basket = await _basketServices.AddGiftsToBasketAsync(addGiftsToBasketDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteGift")]
        public async Task<ActionResult<GetByUserBasketDto>> DeleteGiftsFromBasketDto([FromBody] DeleteGiftsFromBasketDto deleteGiftsFromBasketDto)
        {
            try
            {
                int a = deleteGiftsFromBasketDto.BasketId;
                Console.WriteLine(a);
                var basket = await _basketServices.DeleteGiftsFromBasketAsync(deleteGiftsFromBasketDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPackage")]
        public async Task<ActionResult<GetByUserBasketDto>> AddPackagesToBasketDto(AddPackagesToBasketDto addPackagesToBasketDto)
        {
            try
            {
                var basket = await _basketServices.AddPackagesToBasketAsync(addPackagesToBasketDto);
                _logger.LogInformation("Getting All package");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeletePackage")]
        public async Task<ActionResult<GetByUserBasketDto>> DeletePackageFromBasketDto([FromBody] DeletePackagesFromBasketDto deletePackagesFromBasketDto)
        {
            try
            {
                var basket = await _basketServices.DeletePackagesFromBasketAsync(deletePackagesFromBasketDto);
                _logger.LogInformation("Getting All packages");
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketAsync(int id)
        {
            var deleted = await _basketServices.DeleteBasketAsync(id);
            _logger.LogInformation("Getting All Gift");
            if (!deleted)
                return NotFound();
            return NoContent();
        }


    }
}