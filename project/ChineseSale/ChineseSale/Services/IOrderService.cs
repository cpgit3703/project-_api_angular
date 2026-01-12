using ChineseSale.Dto;
using ChineseSale.Model;
namespace ChineseSale.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetAllOrderAsync();
        Task<GetOrderByIdDto?> GetOrderByIdAsync(int id);
        Task<GetOrderByIdDto?> GetOrderByUserIdAsync(int id);
        Task<GetOrderByIdDto> CreateOrderAsync(CreateOrderDto orderDto);
        Task<IEnumerable<GetUserDto>> GetBuyerGift(int giftId);
    }
}
