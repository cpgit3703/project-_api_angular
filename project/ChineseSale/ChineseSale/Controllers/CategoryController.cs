using Microsoft.AspNetCore.Mvc;
using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;


namespace ChineseSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryServices categoryServices, ILogger<CategoryController> logger)
        {
            _categoryServices = categoryServices;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDonorDto>>> GetAllCategoryAsync()
        {
            var categorys = await _categoryServices.GetAllCategoryAsync();
            _logger.LogInformation("Getting All Gift");
            return Ok(categorys);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetDonorDto>> GetByIdCategoryAsync(int Id)
        {
            try
            {
                var category = await _categoryServices.GetByIdCategoryAsync(Id);
                _logger.LogInformation("Getting All Gift");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public async Task<ActionResult<GetDonorDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                var category = await _categoryServices.CreateCategoryAsync(categoryDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var deleted = await _categoryServices.DeleteCategoryAsync(id);
            _logger.LogInformation("Getting All Gift");

            if (!deleted)
                return NotFound();   

            return NoContent();      
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult<GetCategoryByIdDto>> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = await _categoryServices.UpdateCategoryAsync(categoryDto);
                _logger.LogInformation("Getting All Gift");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
