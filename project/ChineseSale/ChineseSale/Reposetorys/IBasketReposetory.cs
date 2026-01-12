using ChineseSale.Model;

namespace ChineseSale.Repositories
{
    public interface IBasketReposetory
    {
        Task<IEnumerable<Basket>> GetAllBasketAsync();
        Task<Basket?> GetByIdBasketAsync(int id);
        Task<Basket?> GetByUserBasketAsync(int userId);
        Task<Basket> CreateBasketAsync(Basket basket);
        Task<Basket> AddGiftsToBasketAsync(Basket basket,Gift gift);
        Task<Basket> DeleteGiftsFromBasketAsync(Basket basket,Gift gift);
        Task DeleteBasketAsync(Basket basket);
    }
}
