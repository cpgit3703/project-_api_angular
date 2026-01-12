using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSale.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class GiftController:ControllerBase
    {
        private readonly IGiftServices _giftServices;
        private readonly ILogger<GiftController> _logger;
        public GiftController(IGiftServices giftServices,ILogger<GiftController> logger)
        {
            _giftServices=giftServices;
            _logger=logger;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetGiftDto>>> GetAllGiftAsync()
        {
            var gifts=await _giftServices.GetAllGiftAsync();
            _logger.LogInformation("Getting All Gift");
            return Ok(gifts);

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetGiftDto>> GetGiftByIdAsync(int Id)
        {
            try
            {
                var gifts = await _giftServices.GetByIdGiftAsync(Id);
                          _logger.LogInformation("Getting All Gift");
                return Ok(gifts);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]

        public async Task<ActionResult<GetGiftDto>> CreateGiftDtoAsync([FromBody] CreateGiftDto giftDto)
        {
            try { 
            var gifts = await _giftServices.CreateGiftDtoAsync(giftDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(gifts);
            }catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Update")]

        public async Task<ActionResult<IEnumerable<GetGiftDto>>>UpdateGiftAsync(UpdateGiftDto giftDto)
        {
            try
            {
                var gifts = await _giftServices.UpdateGiftAsync(giftDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(gifts);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
  
   

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            var deleted = await _giftServices.DeleteGiftAsync(id);
            _logger.LogInformation("Getting All Gift");

            if (!deleted)
                return NotFound("GiftNotFound");

            return NoContent(); 
        }



        [HttpGet("exists/{Name}")]
        public async Task<ActionResult<GetGiftDto>> ExistsGiftAsync(string name)
        {
            var gifts = await _giftServices.ExistsGiftAsync(name);
            _logger.LogInformation("Getting All Gift");
            return Ok(gifts);
        }

    }
}
