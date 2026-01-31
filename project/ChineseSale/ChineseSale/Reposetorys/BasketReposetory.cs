using ChineseSale.Data;
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Repositories
{
    public class BasketReposetory : IBasketReposetory
    {
        //private readonly ChineseSaleDbContext _context;

        //public BasketReposetory(ChineseSaleDbContext context)
        //{
        //    _context = context;
        //}

        //        public async Task<IEnumerable<Basket>> GetAllBasketAsync()
        //        {
        //            return await _context.Baskets
        //                        .Include(b => b.User)
        //                        .ToListAsync();
        //        }

        //        public async Task<Basket?> GetByIdBasketAsync(int Id)
        //        {
        //            return await _context.Baskets
        //                        .Include(b => b.User)
        //           .FirstOrDefaultAsync(g => g.Id == Id);

        //        }
        //        public async Task<Basket?> GetByUserBasketAsync(int userId)
        //        {
        //            return await _context.Baskets
        //                        .Include(b => b.User)
        //           .FirstOrDefaultAsync(g => g.UserId == userId);

        //        }


        //        public async Task<Basket> CreateBasketAsync(Basket basket)
        //        {
        //            _context.Baskets.Add(basket);
        //            await _context.SaveChangesAsync();
        //            return basket;
        //        }

        //        public async Task DeleteBasketAsync(Basket basket)
        //        {
        //            _context.Baskets.Remove(basket);
        //            await _context.SaveChangesAsync();
        //        }

        //        public async Task<Basket?> AddGiftsToBasketAsync(Basket basket,Gift gift)
        //        {
        //            basket.GiftsId.Add(gift.Id);
        //            basket.Sum += gift.PriceCard;
        //            gift.SumCustomers += 1;
        //            _context.Baskets.Update(basket);
        //            _context.Gifts.Update(gift);
        //            await _context.SaveChangesAsync();
        //            return basket;
        //        }

        //        public async Task<Basket?> DeleteGiftsFromBasketAsync(Basket basket, Gift gift)
        //        {
        //            basket.GiftsId.Remove(gift.Id);
        //            basket.Sum -= gift.PriceCard;
        //            gift.SumCustomers -= 1;
        //            _context.Baskets.Update(basket);
        //            await _context.SaveChangesAsync();
        //            return basket;
        //        }
        private readonly ChineseSaleDbContext _context;
        public BasketReposetory(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Basket>> GetAllBasketAsync()
        {
            return await _context.Baskets
                .Include(Basket => Basket.User)
                .ToListAsync();
        }

        public async Task<Basket?> GetByIdBasketAsync(int Id)
        {
            return await _context.Baskets
                .Include(Basket => Basket.User)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<Basket?> GetByUserBasketAsync(int UserId)
        {
            return await _context.Baskets
                .Include(Basket => Basket.User)
                .FirstOrDefaultAsync(c => c.UserId == UserId);
        }
        public async Task<Basket> CreateBasketAsync(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
            return basket;
        }
        public async Task DeleteBasketAsync(Basket basket)
        {
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
        }
        public async Task<Basket?> AddGiftsToBasketAsync(Basket basket, Gift gift)
        {  
            int basket1 = basket.UserId;
            
          
            basket.GiftsId.Add(gift.Id);
            _context.Baskets.Update(basket);
            gift.SumCustomers += 1;
            _context.Gifts.Update(gift);
            await _context.SaveChangesAsync();

            return basket;
        }
        public async Task<Basket?> DeleteGiftsFromBasketAsync(Basket basket, Gift gift)
        {
            basket.GiftsId.Remove(gift.Id);
            gift.SumCustomers -= 1;
            _context.Gifts.Update(gift);
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

        public async Task<Basket?> AddPackagesToBasketAsync(Basket basket, Package package)
        {
            basket.PackageId.Add(package.Id);
            _context.Baskets.Update(basket);
            basket.Sum += package.Price;
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();

            return basket;
        }
        public async Task<Basket?> DeletePackagesFromBasketAsync(Basket basket, Package package)
        {
            basket.PackageId.Remove(package.Id);
             basket.Sum -= package.Price;
            _context.Packages.Update(package);
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

    }
}

