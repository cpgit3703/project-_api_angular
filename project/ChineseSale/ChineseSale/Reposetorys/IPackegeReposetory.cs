using ChineseSale.Model;

namespace ChineseSale.Repositories
{
    public interface IPackegeReposetory
    {
        Task<IEnumerable<Package>> GetAllPackageAsync();
        Task<Package?> GetByIdPackageAsync(int Id);
        Task<Package> CreatePackageAsync(Package package);
        Task<Package> UpdatePackageAsync(Package package);
        Task DeletePackageAsync(Package package);
     

    }
}
