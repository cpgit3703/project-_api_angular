using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
using System.Collections.Generic;

namespace ChineseSale.Services
{
    public class BasketService:IBasketService
    {
        private readonly IBasketReposetory _basketRepository;
        private readonly IGiftServices _giftService;
        private readonly IGiftReposetory _giftRepository;
        private readonly IPackegeReposetory _packegeReposetory;
        private readonly IPackegeService _packageService;
        public BasketService(IBasketReposetory basketRepository, IGiftServices giftService, IGiftReposetory giftRepository, IPackegeReposetory packegeReposetory, IPackegeService packageService)
        {
            _basketRepository = basketRepository;
            _giftService = giftService;
            _giftRepository = giftRepository;
            _packegeReposetory = packegeReposetory;
            _packageService = packageService;
        }
        public async Task<IEnumerable<GetBasketDto>> GetAllBasketAsync()
        {
            IEnumerable<Basket> baskets = await _basketRepository.GetAllBasketAsync();
            List<GetBasketDto> basketDtos = new List<GetBasketDto>();
            foreach (var basket in baskets)
            {
                GetBasketDto basketDto = new GetBasketDto()
                {
                    Id = basket.Id,
                    UserId = basket.UserId,
                    Sum = basket.Sum
                };
                basketDtos.Add(basketDto);
            }
            return basketDtos;
        }
        public async Task<GetByUserBasketDto?> GetByIdBasketAsync(int Id)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(Id);

            if (basket != null)
            {
                List<GetGiftDto> giftsDto = new List<GetGiftDto>();
                for (int i = 0; i < basket.GiftsId.Count(); i++)
                {
                    GetGiftDto giftDto = await _giftService.GetByIdGiftAsync(basket.GiftsId[i]);
                    giftsDto.Add(giftDto);
                }
                GetByUserBasketDto basketByIdDto = new GetByUserBasketDto()
                {
                    Id = basket.Id,
                    UserId = basket.UserId,
                    Gifts = giftsDto,
                    Sum = basket.Sum
                };
                return basketByIdDto;
            }
            else
                throw new ArgumentException("basket not found");
        }
        public async Task<GetByUserBasketDto?> GetBasketByUserIdAsync(int UserId)
        {
            Basket basket = await _basketRepository.GetByUserBasketAsync(UserId);

            if (basket != null)
            {
                List<GetGiftDto> giftsDto = new List<GetGiftDto>();
                for (int i = 0; i < basket.GiftsId.Count(); i++)
                {
                    GetGiftDto giftDto = await _giftService.GetByIdGiftAsync(basket.GiftsId[i]);
                    giftsDto.Add(giftDto);
                }
                List<GetPackageDto> packageDtos = new List<GetPackageDto>();
                for (int i = 0; i < basket.PackageId.Count(); i++)
                {
                  GetPackageDto packageDto = await _packageService.GetByIdPackageAsync(basket.PackageId[i]);
                    packageDtos.Add(packageDto);
                }
                GetByUserBasketDto basketByIdDto = new GetByUserBasketDto()
                {
                    Id = basket.Id,
                    UserId = basket.UserId,
                    Gifts = giftsDto,
                    Packages = packageDtos,
                    Sum = basket.Sum
                };
                return basketByIdDto;
            }
            else
                throw new ArgumentException("basket not found");
        }
        public async Task<GetBasketDto> CreateBasketAsync(CreateBasketDto basketDto)
        {
            Basket? existsBasket = await _basketRepository.GetByUserBasketAsync(basketDto.UserId);
            if (existsBasket != null)
            {
                throw new ArgumentException("basket for this user already exists");
            }

            Basket basket = new Basket()
            {
                UserId = basketDto.UserId,
            };

            await _basketRepository.CreateBasketAsync(basket);

            return new GetBasketDto
            {
                Id = basket.Id,
                UserId = basket.UserId,
                Sum = basket.Sum
            };
        }

        public async Task<bool> DeleteBasketAsync(int Id)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(Id);
            if (basket == null)
                return false;
            await _basketRepository.DeleteBasketAsync(basket);
            return true;
        }

        public async Task<GetByUserBasketDto> AddGiftsToBasketAsync(AddGiftsToBasketDto giftToBasketDto)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(giftToBasketDto.BasketId);
            if (basket == null)
                throw new ArgumentException("basket not found");
            Gift gift = await _giftRepository.GetByIdGiftAsync(giftToBasketDto.GiftsId);
            await _basketRepository.AddGiftsToBasketAsync(basket, gift);
            return await GetByIdBasketAsync(basket.Id);
        }
        public async Task<GetByUserBasketDto> DeleteGiftsFromBasketAsync(DeleteGiftsFromBasketDto giftToBasketDto)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(giftToBasketDto.BasketId);
            if (basket == null)
                throw new ArgumentException("basket not found");
            Gift gift = await _giftRepository.GetByIdGiftAsync(giftToBasketDto.GiftsId);
            basket.GiftsId.Remove(giftToBasketDto.GiftsId);
            await _basketRepository.DeleteGiftsFromBasketAsync(basket, gift);
            return await GetByIdBasketAsync(basket.Id);
        }
        public async Task<GetByUserBasketDto> AddPackagesToBasketAsync(AddPackagesToBasketDto packagesToBasketDto)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(packagesToBasketDto.BasketId);
            if (basket == null)
                throw new ArgumentException("basket not found");
            Package package = await _packegeReposetory.GetByIdPackageAsync(packagesToBasketDto.PackageId);
            await _basketRepository.AddPackagesToBasketAsync(basket, package);
            return await GetByIdBasketAsync(basket.Id);
        }
        public async Task<GetByUserBasketDto> DeletePackagesFromBasketAsync(DeletePackagesFromBasketDto packagesFromBasketDto)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(packagesFromBasketDto.BasketId);
            if (basket == null)
                throw new ArgumentException("basket not found");
            Package package = await _packegeReposetory.GetByIdPackageAsync(packagesFromBasketDto.PackageId);
            basket.PackageId.Remove(packagesFromBasketDto.PackageId);
            await _basketRepository.DeletePackagesFromBasketAsync(basket, package);
            return await GetByIdBasketAsync(basket.Id);
        }

    }
}
