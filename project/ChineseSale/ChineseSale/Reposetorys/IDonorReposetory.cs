using ChineseSale.Model;
namespace ChineseSale.Repositories
{
    public interface IDonorReposetory
    {
        Task<IEnumerable<Donor>> GetAllDonorsAsync();
        Task<Donor?> GetByIdDonorAsync(int Id);
        Task<Donor> CreateDonorAsync(Donor donor);
        Task DeleteDonorAsync(Donor donor);
        Task<Donor> UpdateDonorAsync(Donor donor);
        Task<Donor?> AddGitfToDonor(Gift gift, Donor donor);

        Task<Donor?> DeleteGitFromDonor(Gift gift, Donor donor);

        Task<IEnumerable<Donor?>> ExistsDonorAsync(string name);
        Task<IEnumerable<Donor?>> ExistsDonorEmailAsync(string email);
        Task<IEnumerable<Donor?>> ExistsDonorAsync(Gift gift);
    }
}
