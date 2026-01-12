using ChineseSale.Data;
using ChineseSale.Dto;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Reposetorys
{
    public class PrizeReposetory: IPrizeReposetory
    {
        private readonly ChineseSaleDbContext _context;

        public PrizeReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Prize>> GetAllPrizesAsync()
        {
           
            return await _context.Prizes
                .Include(p => p.Gift)
                .Include(p => p.User)
              .ToListAsync();
        }
        public async Task<Prize?> GetPrizesByIdAsync(int Id)
        {
            return await _context.Prizes
                .Include(p => p.Gift)
                .Include(p => p.User)
           .FirstOrDefaultAsync(g => g.Id == Id);

        }
        public async Task<Prize?> GetPrizesByUserIdAsync(int Id)
        {
            return await _context.Prizes
                .Include(p => p.Gift)
                .Include(p => p.User)
           .FirstOrDefaultAsync(g => g.UserId == Id);

        }
        public async Task<Prize> CreatePrizesAsync(Prize prize)
        {
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();
            return prize;
        }
    }
}
