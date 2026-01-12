using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Services;
using Microsoft.AspNetCore.Mvc;
namespace ChineseSale.Controllers
{
    [ApiController]
     [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        public readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var orders = await _orderService.GetAllOrderAsync();
            _logger.LogInformation("Getting All Gift");
            return Ok(orders);
        }
        [HttpGet("{Id}")]
        public async  Task<IActionResult> GetOrderByIdAsync( int Id)
        {
            var order = await _orderService.GetOrderByIdAsync(Id);
            _logger.LogInformation("Getting All Gift");
            return Ok(order);
        }
        [HttpGet("user/{userId}")]
        public async  Task<IActionResult> GetOrderByUserIdAsync( int userId)
        {
            var order = await _orderService.GetOrderByUserIdAsync(userId);
            _logger.LogInformation("Getting All Gift");
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto createOrderDto)
        {
            var order = await _orderService.CreateOrderAsync(createOrderDto);
            _logger.LogInformation("Getting All Gift");
            return Ok(order);
        }
        [HttpGet("gift/{giftId}/buyers")]
        public async Task<IActionResult> GetBuyerGift(int giftId)
        {
            var buyers = await _orderService.GetBuyerGift(giftId);
            _logger.LogInformation("Getting All Gift");
            return Ok(buyers);
        }
    }
}
