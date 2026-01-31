using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;

namespace ChineseSale.Services
{
    public class GiftServices : IGiftServices
    {
        private readonly IGiftReposetory _repository;
        private readonly ICategoryReposetory  _categoryReposetories;
        private readonly IDonorReposetory _donorRepositories;
        public GiftServices(IGiftReposetory repositories, ICategoryReposetory categoryReposetories, IDonorReposetory donorRepositories)
        {
            _repository= repositories;
            _categoryReposetories= categoryReposetories;
            _donorRepositories= donorRepositories;
        }
        public async Task<IEnumerable<GetGiftDto>> GetAllGiftAsync()
        {
            IEnumerable<Gift> gifts = await _repository.GetAllGiftAsync();
            List<GetGiftDto> giftdtos = new List<GetGiftDto>();

            foreach (var gift in gifts)
            {
                GetGiftDto gettGiftDto = new GetGiftDto()
                {
                    Id = gift.Id,
                    Name = gift.Name,
                    Description = gift.Description,
                    Value = gift.Value,
                    Category =new GetCategoryDto() {
                        Id = gift.Category.Id,
                        Name = gift.Category.Name
                    },
                    Donor = new GetDonorDto() { 
                        Id = gift.Donor.Id,
                        Name = gift.Donor.Name,
                        Email=gift.Donor.Email,
                        Phone=gift.Donor.Phone
                    }
                    ,
                    SumCustomers = gift.SumCustomers,
                    Image = gift.Image,
                   
                };

                giftdtos.Add(gettGiftDto);
            }

            return giftdtos;
        }

        public async Task<GetGiftDto?> GetByIdGiftAsync(int Id)
        {
            Gift gift = await _repository.GetByIdGiftAsync(Id);
            if (gift == null)
                throw new AggregateException("gift not found");
            Console.WriteLine(gift);
            GetGiftDto gettGiftDto = new GetGiftDto()
            {
                Id = gift.Id,
                Name = gift.Name,
                Description = gift.Description,
                Value = gift.Value,
                Category = new GetCategoryDto()
                {
                    Id = gift.Category.Id,
                    Name = gift.Category.Name
                },
                Donor = new GetDonorDto()
                {
                    Id = gift.Donor.Id,
                    Name = gift.Donor.Name,
                    Email = gift.Donor.Email,
                    Phone = gift.Donor.Phone
                },
                SumCustomers = gift.SumCustomers,
                Image = gift.Image,
               
            };
            return gettGiftDto;
           
        }
        public async Task<GetGiftDto> CreateGiftDtoAsync(CreateGiftDto GiftDto)
        {

            if (GiftDto.Value <= 0 )
            {
                throw new AggregateException("Value and PriceCard must be greater than 0");
            }
            Gift gift=new Gift()
            {
                Name = GiftDto.Name,
                Description = GiftDto.Description,
                Value = GiftDto.Value,
                CategoryId = GiftDto.CategoryId,
                DonorId = GiftDto.DonorId,
                Image = GiftDto.Image,
            };
           Gift gift1 = await _repository.CreateGiftAsync(gift);
           Gift gift2 = await _repository.GetByIdGiftAsync(gift1.Id);

            GetGiftDto GiftDto2 = new GetGiftDto()
            {
                Name = gift2.Name,
                Description = gift2.Description,
                Value = gift2.Value,
           
                Category = new GetCategoryDto()
                {
                    Id = gift.Category.Id,
                    Name = gift.Category.Name
                },
                Donor = new GetDonorDto()
                {
                    Id = gift.Donor.Id,
                    Name = gift.Donor.Name,
                    Email = gift.Donor.Email,
                    Phone = gift.Donor.Phone
                },
                SumCustomers = gift.SumCustomers,
                Image = gift2.Image,
                
            };
           await _donorRepositories.AddGitfToDonor(gift2,gift2.Donor);
           await _categoryReposetories.AddGitfToCategory(gift2, gift2.Category);
            return GiftDto2;
        }

        public async Task<bool> DeleteGiftAsync(int id)
        {
           Gift gift = await _repository.GetByIdGiftAsync(id);
            if (gift == null)
                return false;
            await _repository.DeleteGiftAsync(gift);
            await _categoryReposetories.DeleteGitFromCategory(gift, gift.Category);
            await _donorRepositories.DeleteGitFromDonor(gift, gift.Donor);
            return true;

        }

        public async Task<IEnumerable< GetGiftDto?>> ExistsGiftAsync(string name)
        {
           
            IEnumerable<Gift> gifts = await _repository.ExistsGiftAsync(name);
            List<GetGiftDto> giftdtos = new List<GetGiftDto>();

            foreach (var gift in gifts)
            {
                GetGiftDto gettGiftDto = new GetGiftDto()
                {
                    Id = gift.Id,
                    Name = gift.Name,
                    Description = gift.Description,
                    Value = gift.Value,
              
                    Category = new GetCategoryDto()
                    {
                        Id = gift.Category.Id,
                        Name = gift.Category.Name
                    },
                    Donor = new GetDonorDto()
                    {
                        Id = gift.Donor.Id,
                        Name = gift.Donor.Name,
                        Email = gift.Donor.Email,
                        Phone = gift.Donor.Phone
                    },
                    SumCustomers = gift.SumCustomers,
                    Image = gift.Image,
                    
                };

                giftdtos.Add(gettGiftDto);
            }

            return giftdtos;
        }
        public async Task<GetGiftDto> UpdateGiftAsync(UpdateGiftDto GiftDto)

        {
            Gift gift = await _repository.GetByIdGiftAsync(GiftDto.Id);
            Category oldcategory=gift.Category; 
            Donor olddonor= gift.Donor;
            if (gift==null)
                throw new AggregateException("not found gift");
            if (GiftDto.Value <= 0)
            {
                throw new AggregateException("Value  must be greater than 0");
            }
           gift.Name=GiftDto.Name;
           gift.Value = GiftDto.Value;
           gift.Description= GiftDto.Description;
           gift.DonorId= GiftDto.DonorId;
           gift.CategoryId = GiftDto.CategoryId;
           gift.Image= GiftDto.Image;
      
      

            Gift gift1 = await _repository.UpdateGiftAsync(gift);
            GetGiftDto GiftDto2 = new GetGiftDto()
            {
                Name = gift1.Name,
                Description = gift1.Description,
                Value = gift1.Value,
                Category = new GetCategoryDto()
                {
                    Id = gift.Category.Id,
                    Name = gift.Category.Name
                },
                Donor = new GetDonorDto()
                {
                    Id = gift.Donor.Id,
                    Name = gift.Donor.Name,
                    Email = gift.Donor.Email,
                    Phone = gift.Donor.Phone
                },
                SumCustomers = gift1.SumCustomers,
                Image = gift1.Image,
                
            };
            if(oldcategory.Id != gift1.Category.Id) {

            await _categoryReposetories.DeleteGitFromCategory(gift, gift.Category);
            await _categoryReposetories.AddGitfToCategory(gift1, gift1.Category); }
            if (olddonor.Id != gift1.Donor.Id)
            {
                await _donorRepositories.DeleteGitFromDonor(gift, gift.Donor);
                await _donorRepositories.AddGitfToDonor(gift1, gift1.Donor);
            }
                return GiftDto2;
        }
    }
}
