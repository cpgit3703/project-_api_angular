using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Repositories
{
    public class DonorReposetory : IDonorReposetory
    {
        private readonly ChineseSaleDbContext _context;

        public DonorReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
        {
            return await _context.Donors
               .Include(c => c.Gifts)
               .ToListAsync();
        }

        public async Task<Donor?> GetByIdDonorAsync(int Id)
        {
            return await _context.Donors
                  .Include(c => c.Gifts)
                  .ThenInclude(g => g.Category)
                 .FirstOrDefaultAsync(g => g.Id == Id);
        }
        public async Task<Donor?> AddGitfToDonor(Gift gift, Donor donor)
        {
            donor.Gifts.Add(gift);
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public async Task<Donor> CreateDonorAsync(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public async Task DeleteDonorAsync(Donor donor)
        {

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<Donor?> DeleteGitFromDonor(Gift gift, Donor donor)
        {
            donor.Gifts.Remove(gift);
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

       

        public async Task<Donor> UpdateDonorAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
            return donor;
        }
        public async Task<IEnumerable<Donor?>> ExistsDonorAsync(string name)
        {
            return await _context.Donors
            .Where(g => g.Name.ToLower() == name.ToLower())
            .Include(g => g.Gifts)
            .ToListAsync();
        }
        public async Task<IEnumerable<Donor?>> ExistsDonorEmailAsync(string email)
        {
            return await _context.Donors
            .Where(g => g.Email == email)
            .Include(g => g.Gifts)
            .ToListAsync();
        }
        public async Task<IEnumerable<Donor?>> ExistsDonorAsync(Gift gift)
        {
            return await _context.Donors
          .Include(d => d.Gifts)
          .Where(d => d.Gifts.Any(g => g.Id == gift.Id))
          .ToListAsync();
        }
    }
}
