using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Repositories
{
    public class OrderReposetory:IOrderReposetory
    {
        private readonly ChineseSaleDbContext _context;

        public OrderReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _context.Orders
                        .Include(o => o.User)
                        .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int Id)
        {
            return await _context.Orders
                        .Include(b => b.User)
           .FirstOrDefaultAsync(g => g.Id == Id);

        }
        public async Task<Order?> GetOrderByUserIdAsync(int userId)
        {
            return await _context.Orders
                        .Include(b => b.User)
           .FirstOrDefaultAsync(g => g.UserId == userId);

        }


        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

    }
}
