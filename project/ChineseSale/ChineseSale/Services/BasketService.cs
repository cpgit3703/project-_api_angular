using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
using System.Collections.Generic;

namespace ChineseSale.Services
{
    public class BasketService:IBasketService
    {
        //private readonly IBasketReposetory _repository;
        //private readonly IGiftServices _giftservice;
        //private readonly IGiftReposetory _giftrepository;
        //public BasketService(IBasketReposetory repository, IGiftServices giftservice, IGiftReposetory giftrepository)
        //{

        //    _repository = repository;
        //    _giftservice=giftservice;
        //    _giftrepository = giftrepository;
        //}
        //public async Task<IEnumerable<GetBasketDto>> GetAllBasketAsync()
        //{

        //    IEnumerable<Basket> baskets = await _repository.GetAllBasketAsync();
        //    List<GetBasketDto> basketDtos = new List<GetBasketDto>();

        //    foreach (var category in baskets)
        //    {
        //        GetBasketDto GetBasketDto = new GetBasketDto()
        //        {
        //            Id = category.Id,
        //            UserId = category.UserId
        //        };

        //        basketDtos.Add(GetBasketDto);
        //    }

        //    return basketDtos;
        //}
        //public async Task<GetByUserBasketDto?> GetByIdBasketAsync(int userId)
        //{
        //    Basket basket = await _repository.GetByIdBasketAsync(userId);
        //    if (basket == null)
        //        throw new AggregateException("basket not found");
        //    List<GetGiftDto> gifts = new List<GetGiftDto>();
        //    for (int i = 0; i < basket.GiftsId.Count(); i++)
        //    {

        //        GetGiftDto gift = await _giftservice.GetByIdGiftAsync(basket.GiftsId[i]);
        //        if (gift != null)
        //        {
        //            gifts.Add(gift);
        //        }

        //    }


        //    GetByUserBasketDto getByUserBasketDto = new GetByUserBasketDto()
        //    {

        //        Id = basket.Id,
        //        UserId = basket.UserId,
        //        Gifts = gifts,
        //        Sum = basket.Sum
        //    };
        //    return getByUserBasketDto;
        //}
        //public async Task<GetByUserBasketDto?> GetByUserBasketDto(int userId)
        //{
        //    Basket basket = await _repository.GetByUserBasketAsync(userId);
        //    if (basket == null)
        //        throw new AggregateException("basket not found");
        //    List<GetGiftDto> gifts = new List<GetGiftDto>();
        //    for (int i = 0; i < basket.GiftsId.Count(); i++)
        //    {

        //        GetGiftDto gift = await _giftservice.GetByIdGiftAsync(basket.GiftsId[i]);
        //        if (gift != null)
        //        {
        //            gifts.Add(gift);
        //        }

        //    }


        //    GetByUserBasketDto getByUserBasketDto = new GetByUserBasketDto()
        //    {

        //        Id = basket.Id,
        //        UserId = basket.UserId,
        //        Gifts = gifts,
        //        Sum = basket.Sum
        //    };
        //    return getByUserBasketDto;
        //}
        //public async Task<GetBasketDto> CreateBasketAsync(CreateBasketDto BasketDto)
        //{
        //    Basket basket = new Basket()
        //    {

        //        UserId = BasketDto.UserId,



        //    };
        //    Basket? basket2=await _repository.GetByUserBasketAsync(BasketDto.UserId);
        //    if(basket2 != null)
        //        throw new AggregateException("basket already exists for this user");
        //    await _repository.CreateBasketAsync(basket);
        //    Basket basket1 = await _repository.GetByIdBasketAsync(basket.Id);
        //    GetBasketDto getBasketDto = new GetBasketDto()
        //    {

        //        Id = basket1.Id,
        //        UserId = basket1.UserId,
        //    };
        //    return getBasketDto;

        //}

        //public async Task<bool> DeleteBasketAsync(int id)
        //{
        //    Basket basket = await _repository.GetByIdBasketAsync(id);
        //    if (basket == null )
        //        return false;
        //    await _repository.DeleteBasketAsync(basket);
        //    return true;
        //}

        //public async Task<GetByUserBasketDto?> AddGiftsToBasketDto(AddGiftsToBasketDto GiftsToBasketDto)
        //{
        //    Basket basket = await _repository.GetByIdBasketAsync(GiftsToBasketDto.BasketId);
        //    if (basket == null)
        //        throw new AggregateException("basket not found");
        //    Gift gift = await _giftrepository.GetByIdGiftAsync(GiftsToBasketDto.GiftstId);
        // await _repository.AddGiftsToBasketAsync(basket, gift);
        //    return await GetByIdBasketAsync(basket.Id);
        //}

        //public async Task<GetByUserBasketDto?> DeleteGiftsFromBasketDto(DeleteGiftsFromBasketDto GiftsToBasketDto)
        //{
        //    Basket basket = await _repository.GetByIdBasketAsync(GiftsToBasketDto.BasketId);
        //    if (basket == null)
        //        throw new AggregateException("basket not found");
        //    Gift gift = await _giftrepository.GetByIdGiftAsync(GiftsToBasketDto.GiftstId);
        //    await _repository.DeleteGiftsFromBasketAsync(basket, gift);
        //    return await GetByIdBasketAsync(basket.Id);


        //}

        private readonly IBasketReposetory _basketRepository;
        private readonly IGiftServices _giftService;
        private readonly IGiftReposetory _giftRepository;
        public BasketService(IBasketReposetory basketRepository, IGiftServices giftService, IGiftReposetory giftRepository)
        {
            _basketRepository = basketRepository;
            _giftService = giftService;
            _giftRepository = giftRepository;
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
            Gift gift = await _giftRepository.GetByIdGiftAsync(giftToBasketDto.GiftstId);
            await _basketRepository.AddGiftsToBasketAsync(basket, gift);
            return await GetByIdBasketAsync(basket.Id);
        }
        public async Task<GetByUserBasketDto> DeleteGiftsFromBasketAsync(DeleteGiftsFromBasketDto giftToBasketDto)
        {
            Basket basket = await _basketRepository.GetByIdBasketAsync(giftToBasketDto.BasketId);
            if (basket == null)
                throw new ArgumentException("basket not found");
            Gift gift = await _giftRepository.GetByIdGiftAsync(giftToBasketDto.GiftstId);
            basket.GiftsId.Remove(giftToBasketDto.GiftstId);
            await _basketRepository.DeleteGiftsFromBasketAsync(basket, gift);
            return await GetByIdBasketAsync(basket.Id);
        }

    }
}
