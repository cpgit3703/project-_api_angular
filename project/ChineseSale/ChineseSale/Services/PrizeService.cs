using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Reposetorys;
using ChineseSale.Repositories;
using System.Net;
using System.Net.Mail;


namespace ChineseSale.Services
{
    public class PrizeService : IPrizeService
    {
        private readonly IPrizeReposetory _repository;
        private readonly IGiftReposetory _giftReposetory;
        private readonly IOrderService _orderService;
       private readonly IEmailService _emailService;
        private readonly IUserReposerory _userReposerory;
        public PrizeService(IPrizeReposetory repository, IGiftReposetory giftReposetory, IOrderService orderService, IEmailService emailService, IUserReposerory userReposerory)
        {
            _repository = repository;
            _giftReposetory = giftReposetory;
            _orderService = orderService;
            _emailService=emailService;
             _userReposerory=userReposerory;
        }
        public async Task<IEnumerable<GetPrizeDto>> GetAllPrizesAsync()
        {
            IEnumerable<Prize> prizes = await _repository.GetAllPrizesAsync();
            List<GetPrizeDto> prizeDtos = new List<GetPrizeDto>();
            Console.WriteLine("66");
            foreach (var prize in prizes)
            {
                prizeDtos.Add(new GetPrizeDto
                {
                    Id = prize.Id,
                    UserId = prize.UserId,
                    GiftId = prize.GiftId
                });
            }
            return prizeDtos;
        }
        public async Task<GetPrizeDto?> GetPrizesByIdAsync(int Id)
        {
            Prize prize = await _repository.GetPrizesByIdAsync(Id);
            if (prize == null)
                throw new AggregateException("prize not found");

            GetPrizeDto getPrizeDto = new GetPrizeDto()
            {

                Id = prize.Id,
                UserId = prize.UserId,
                GiftId = prize.GiftId


            };
            return getPrizeDto;
        }
        public async Task<GetPrizeDto?> GetPrizesByUserIdAsync(int Id)
        {
            Prize prize = await _repository.GetPrizesByUserIdAsync(Id);
            if (prize == null)
                throw new AggregateException("prize not found");

            GetPrizeDto getPrizeDto = new GetPrizeDto()
            {

                Id = prize.Id,
                UserId = prize.UserId,
                GiftId = prize.GiftId


            };
            return getPrizeDto;
        }
        public async Task<GetPrizeDto> CreatePrizesAsync(CreatePrizeDto prizeDto)
        {
            

            Prize prize = new Prize()
            {
                UserId = prizeDto.UserId,
                GiftId = prizeDto.GiftId
            };

            await _repository.CreatePrizesAsync(prize);
            Prize prize1 = await _repository.GetPrizesByIdAsync(prize.Id);
            GetPrizeDto getPrizeDto = new GetPrizeDto()
            {

                Id = prize1.Id,
                UserId = prize1.UserId,
                GiftId = prize1.GiftId
            };
            return getPrizeDto;

        }
        public async Task<GetPrizeDto> SelectRandomPrize(int giftId)
        {
            int a = giftId;
            a=a;
            Gift gift = await _giftReposetory.GetByIdGiftAsync(giftId);
            a = gift.Id;
            if (gift == null)
                throw new Exception("Gift not found");

            if (gift.SumCustomers <= 0)
                throw new Exception("No customers");

            Random random = new Random();

            while (true)
            {
               
                int num = random.Next(1, gift.SumCustomers + 1);
                var order = await _orderService.GetOrderByIdAsync(giftId);

                if (order != null)
                {
                    return new GetPrizeDto
                    {
                        UserId = order.UserId,
                        GiftId = giftId
                    };
                }
            }
        }
        public async Task<GetPrizeDto?> PickWinnerAndSendEmailAsync(int giftId)
        {
           
            var prizeDto = await SelectRandomPrize(giftId);
            if (prizeDto == null)
                return null;

           
            var user = await _userReposerory.GetByIdUserAsync(prizeDto.UserId);
            if (user == null || string.IsNullOrEmpty(user.Email))
                throw new Exception("User email not found");

          
            await _emailService.SendEmailAsync(
                user.Email,
                "🎉 זכית בהגרלה!",
                $"שלום {user.Name}, זכית בהגרלה! 🎁"
            );

            return prizeDto;
        }



    }

}
