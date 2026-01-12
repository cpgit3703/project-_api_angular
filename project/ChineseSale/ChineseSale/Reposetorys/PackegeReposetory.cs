using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Repositories
{
    public class PackegeReposetory: IPackegeReposetory
    {
        private readonly ChineseSaleDbContext _context;

        public PackegeReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Package>> GetAllPackageAsync()
        {
            return await _context.Packages
            .ToListAsync();
        }

        public async Task<Package?> GetByIdPackageAsync(int Id)
        {
            return await _context.Packages
           .FirstOrDefaultAsync(g => g.Id == Id);

        }
       

        public async Task<Package> CreatePackageAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return package;
        }

        public async Task DeletePackageAsync(Package package)
        {
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
        }

        public async Task<Package> UpdatePackageAsync(Package package)
        {
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();
            return package;
        }

    }
}
