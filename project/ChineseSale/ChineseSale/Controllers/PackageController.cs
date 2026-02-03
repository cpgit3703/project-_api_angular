using Microsoft.AspNetCore.Mvc;
using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;

namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackegeService _packegeService;
        private readonly ILogger<PackageController> _logger;
        public PackageController(IPackegeService packegeService, ILogger<PackageController> logger)
        {
            _packegeService = packegeService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPackageDto>>> GetAllPackageAsync()
        {
            var packages = await _packegeService.GetAllPackageAsync();
            _logger.LogInformation("Getting All Packege");
            return Ok(packages);

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetPackageDto>> GetByIdPackageAsync(int Id)
        {
            try
            {
                var package = await _packegeService.GetByIdPackageAsync(Id);
                _logger.LogInformation("Getting All Packege");
                return Ok(package);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<GetPackageDto>> CreatePackageAsync(CreatePackageDto createPackageDto)
        {
            try
            {
                var package = await _packegeService.CreatePackageAsync(createPackageDto);
                _logger.LogInformation("Getting All Packege");
                return Ok(package);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

                return BadRequest(message);
            }

        }
        [HttpDelete("{Id}")]

        public async Task<ActionResult> DeletePackageAsync(int Id)
        {
            try
            {
                await _packegeService.DeletePackageAsync(Id);
                _logger.LogInformation("Getting All Packege");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<GetPackageDto>> UpdatePackageAsync(UpdatePackageDto updatePackageDto)
        {
            try
            {
                var package = await _packegeService.UpdatePackageAsync(updatePackageDto);
                _logger.LogInformation("Getting All Packege");
                return Ok(package);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
    
