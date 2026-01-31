using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
namespace ChineseSale.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReposetory _repository;
        private readonly IGiftServices _giftservice;
        private readonly IPackegeService _packegeService;
        private readonly IUserReposerory _userrepository;
        public OrderService(IOrderReposetory repository, IGiftServices giftservice, IUserReposerory userrepository,
            IPackegeService packegeService)
        {

            _repository = repository;
            _giftservice = giftservice;
            _userrepository = userrepository;
            _packegeService = packegeService;
        }
        public async Task<IEnumerable<GetOrderDto>> GetAllOrderAsync()
        {

            IEnumerable<Order> orders = await _repository.GetAllOrderAsync();
            List<GetOrderDto> orderDtos = new List<GetOrderDto>();

            foreach (var order in orders)
            {
                GetOrderDto GetOrderDto = new GetOrderDto()
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    Sum = order.Sum,
                    OrdeData = order.OrdeData,
                    
                };
                orderDtos.Add(GetOrderDto);
            }

            return orderDtos;
        }
        public async Task<GetOrderByIdDto?> GetOrderByIdAsync(int userId)
        {
         
            Order order = await _repository.GetOrderByIdAsync(userId);
           
            if (order == null)
                throw new AggregateException("order not found");

            List<GetGiftDto> orders = new List<GetGiftDto>();
            for (int i = 0; i < order.GiftsId.Count(); i++)
            {

                GetGiftDto gift = await _giftservice.GetByIdGiftAsync(order.GiftsId[i]);
                if (order != null)
                {
                    orders.Add(gift);
                }

            }
            List<GetPackageDto> packages = new List<GetPackageDto>();
            for (int i = 0; i < order.PackageId.Count(); i++)
            {

                GetPackageDto package = await _packegeService.GetByIdPackageAsync(order.PackageId[i]);
                if (order != null)
                {
                    packages.Add(package);
                }

            }

            GetOrderByIdDto getOrderByIdDto = new GetOrderByIdDto()
            {

                Id = order.Id,
                UserId = order.UserId,
                GiftsId = orders,
                Sum = order.Sum,
                OrdeData = order.OrdeData,
                PackageId=packages

            };
            return getOrderByIdDto;
        }
        public async Task<GetOrderByIdDto?> GetOrderByUserIdAsync(int userId)
        {
            Order order = await _repository.GetOrderByIdAsync(userId);
            if (order == null)
                throw new AggregateException("order not found");

            List<GetGiftDto> orders = new List<GetGiftDto>();
            for (int i = 0; i < order.GiftsId.Count(); i++)
            {

                GetGiftDto gift = await _giftservice.GetByIdGiftAsync(order.GiftsId[i]);
                if (order != null)
                {
                    orders.Add(gift);
                }

            }
            List<GetPackageDto> packages = new List<GetPackageDto>();
            for (int i = 0; i < order.PackageId.Count(); i++)
            {

                GetPackageDto package = await _packegeService.GetByIdPackageAsync(order.PackageId[i]);
                if (order != null)
                {
                    packages.Add(package);
                }

            }

            GetOrderByIdDto getOrderByIdDto = new GetOrderByIdDto()
            {

                Id = order.Id,
                UserId = order.UserId,
                GiftsId = orders,
                Sum = order.Sum,
                OrdeData = order.OrdeData,
                PackageId=packages

            };
            return getOrderByIdDto;
        }

        public async Task<GetOrderByIdDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
            // יצירת הזמנה חדשה
            Order order = new Order()
            {
                UserId = orderDto.UserId,
                Sum = orderDto.Sum,
                OrdeData = DateTime.Now,
                GiftsId= orderDto.GiftsId,
                PackageId = orderDto.PackageId,
            };

            // בדיקה אם כבר קיימת הזמנה עבור המשתמש
            Order? existingOrder = await _repository.GetOrderByUserIdAsync(orderDto.UserId);
      

            // שמירת ההזמנה ב־DB
            await _repository.CreateOrderAsync(order);

            // שליפת ההזמנה שנשמרה (באמצעות UserId)
            Order order2 = await _repository.GetOrderByUserIdAsync(orderDto.UserId);
            if (order2 == null)
                throw new Exception("Failed to retrieve the created order");

            // החזרת DTO של ההזמנה
            return await GetOrderByIdAsync(order2.Id);
        }

        public async Task<IEnumerable<GetUserDto>> GetBuyerGift(int giftId)
        {
            var orders = (await _repository.GetAllOrderAsync()).ToList();
            List<GetUserDto> users = new();

            foreach (var order in orders)
            {
                for (int i = 0; i < order.GiftsId.Count(); i++)
                {
                    if (order.GiftsId[i] == giftId)
                    {
                        var user = await _userrepository.GetByIdUserAsync(order.UserId);
                        if (user != null)
                        {
                            users.Add(new GetUserDto
                            {

                                Id = user.Id,
                                UserName = user.UserName,
                                Name = user.Name,
                                Phone = user.Phone,
                                Address = user.Address,
                                Email = user.Email,
                                Role = user.Role
                            });
                        }
                    }
                }

                
            }
            return users;
        }
    }
}
