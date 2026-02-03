using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ChineseSale.Repositories
{
    public class GiftReposetory : IGiftReposetory
    { 
        private readonly ChineseSaleDbContext _context;
       
        public GiftReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gift>> GetAllGiftAsync()
        {
            return await _context.Gifts
                .Include(g=>g.Category).
                 Include(d=>d.Donor)
                .ToListAsync();
        }
        public async Task<Gift?> GetByIdGiftAsync(int Id)
        {
           return await _context.Gifts
                .Include(g => g.Category).
                 Include(d => d.Donor)
                .FirstOrDefaultAsync(g => g.Id == Id);

        }
        public async Task<Gift>CreateGiftAsync(Gift gift)
        {
            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();
            return gift;
        }

        public async Task DeleteGiftAsync(Gift gift)
        {
            
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
       
        }

        public async Task<IEnumerable<Gift?>> ExistsGiftAsync(string name)
        {
            return await _context.Gifts
            .Where(g => g.Name == name)
            .Include(g => g.Category).
             Include(d => d.Donor)
            .ToListAsync();
        }

        public async Task<IEnumerable<Gift?>> ExistsGiftDonorAsync(int donor)
        {
            return await _context.Gifts
            .Where(g => g.DonorId == donor)
            .Include(g => g.Category)
            .Include(d => d.Donor)
            .ToListAsync();
        }
        public async Task<IEnumerable<Gift?>> ExistsGiftAsync(int sumCustomers)
        {
           return await _context.Gifts
          .Where(d => d.SumCustomers==sumCustomers)
          .Include(g => g.Category).
           Include(d => d.Donor)

          .ToListAsync();
        }
        public async Task<Gift> UpdateGiftAsync(Gift gift)
        {
            _context.Gifts.Update(gift);
            await _context.SaveChangesAsync();
            return gift;
        }
    }
}
