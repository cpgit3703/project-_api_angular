using ChineseSale.Model;
namespace ChineseSale.Repositories
{
    public interface IOrderReposetory
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order?> GetOrderByUserIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
      
    }
}
