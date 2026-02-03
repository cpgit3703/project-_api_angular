using Microsoft.AspNetCore.Mvc;
using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;

namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrizeController: ControllerBase
    {
        private readonly IPrizeService _prizeService;
        private readonly ILogger<PrizeController> _logger;
        public PrizeController(IPrizeService prizeService, ILogger<PrizeController> logger)
        {
            _prizeService = prizeService;
            _logger = logger;
        }
        [HttpGet]


        public async Task<ActionResult<IEnumerable<GetPackageDto>>> GetAllPackageAsync()
        {
            var packages = await _prizeService.GetAllPrizesAsync();
            _logger.LogInformation("Getting All Prize");
            Console.WriteLine("hhh");
            return Ok(packages);

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetPrizeDto>> GetPrizesByIdAsync(int Id)
        {
            try
            {
                var prize = await _prizeService.GetPrizesByIdAsync(Id);
                _logger.LogInformation("Getting All Prize");
                return Ok(prize);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("prize/{userId}")]
        public async Task<ActionResult<GetPrizeDto>> GetPrizesByUserIdAsync(int userId)
        {
            try
            {
                var prize = await _prizeService.GetPrizesByUserIdAsync(userId);
                _logger.LogInformation("Getting All Prize");
                return Ok(prize);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SelectRandomPrize/{giftId}")]
        public async Task<IActionResult> SelectRandomPrize(int giftId)
        {
            try
            {
                var prize = await _prizeService.SelectRandomPrize(giftId);
                return Ok(prize);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("pick-winner/{giftId}")]
        public async Task<IActionResult> PickWinner(int giftId)
        {
            var result = await _prizeService.PickWinnerAndSendEmailAsync(giftId);
            _logger.LogInformation("Getting All Prize");

            if (result == null)
                return NotFound("לא נמצא זוכה");

            return Ok(result);
        }







    }
}

