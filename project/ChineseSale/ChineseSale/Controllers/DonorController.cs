using Microsoft.AspNetCore.Mvc;
using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;

namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {

        private readonly IDonorService _donorService;
        private readonly ILogger<DonorController> _logger;
        public DonorController(IDonorService donorService, ILogger<DonorController> logger)
        {
            _donorService = donorService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDonorDto>>> GetAllDonorAsync()
        {
            var donors = await _donorService.GetAllDonorAsync();
            _logger.LogInformation("Getting All Gift");
            return Ok(donors);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetByIdDonorDto>> GetByIdDonorAsync(int Id)
        {
            try
            {
                var donor = await _donorService.GetByIdDonorDtoAsync(Id);
                _logger.LogInformation("Getting All Gift");
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<GetDonorDto>> CreateDonorAsync(CreateDonorDto createDonorDto)
        {
            try
            {
                var donor = await _donorService.CreateDonorAsync(createDonorDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<GetByIdDonorDto>> UpdateDonorAsync(UpdateDonorDto updateDonorDto)
        {
            try

            {
                Console.WriteLine(updateDonorDto.Email);
                var donor = await _donorService.UpdateDonorAsync(updateDonorDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonorAsync(int id)
        {
            var deleted = await _donorService.DeleteDonorAsync(id);
            _logger.LogInformation("Getting All Gift");
            if (!deleted)
                return NotFound();   // 404 – לא קיים
            return NoContent();    // 204 – נמחק בהצלחה
        }

        [HttpGet("exists/{name}")]
        public async Task<ActionResult<GetDonorDto>> ExistsGiftAsync(string name)
        {
            var donors = await _donorService.ExistsDonorAsync(name);
            _logger.LogInformation("Getting All donor");
            return Ok(donors);
        }
        [HttpGet("exists/donor/{email}")]
        public async Task<ActionResult<GetDonorDto>> ExistsDonorEmailAsync(string email)
        {
            var donors = await _donorService.ExistsDonorEmailAsync(email);
            _logger.LogInformation("Getting All donor");
            return Ok(donors);
        }

        [HttpGet("exists/donor/{gift}")]
        public async Task<ActionResult<GetDonorDto>> ExistsDonorEmailAsync(Gift gift)
        {
            var donors = await _donorService.ExistsDonorAsync(gift);
            _logger.LogInformation("Getting All donor");
            return Ok(donors);
        }
    }


}
