using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
using System.Collections.Generic;

namespace ChineseSale.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorReposetory _repository;
        private readonly IGiftServices _giftservice;
        public DonorService(IDonorReposetory repository, IGiftServices giftservice)
        {

            _repository = repository;
            _giftservice = giftservice;
           
        }

        public async Task<IEnumerable<GetDonorDto>> GetAllDonorAsync()
        {

            IEnumerable<Donor> donors = await _repository.GetAllDonorsAsync();

             return donors.Select(d => new GetDonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                Phone = d.Phone
            }).ToList();

         }

        public async Task<GetByIdDonorDto?> GetByIdDonorDtoAsync(int Id)
        {
            Donor donor = await _repository.GetByIdDonorAsync(Id);
            if (donor == null)
                throw new AggregateException("donor not found");
            List<GetGiftDto> giftdtos = new List<GetGiftDto>();
            foreach (var gift in donor.Gifts)
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
                    Image = gift.Image
                };

               giftdtos.Add(gettGiftDto);
            }
            GetByIdDonorDto getByIdDonorDto = new GetByIdDonorDto()
            {
                Id = donor.Id,
                Name = donor.Name,
                Email = donor.Email,
                Phone =donor.Phone,
                Gifts = giftdtos
            };
            return getByIdDonorDto;
        }
        public async Task<GetDonorDto> CreateDonorAsync(CreateDonorDto createDonorDto)
        {

            Donor donor = new Donor()
            {
                Name= createDonorDto.Name,
                Email= createDonorDto.Email,
                Phone = createDonorDto.Phone,

            };
            await _repository.CreateDonorAsync(donor);
            Donor donor1 = await _repository.GetByIdDonorAsync(donor.Id);
            GetDonorDto getDonorDto = new GetDonorDto()
            {
                Id= donor1.Id,
                Name = donor1.Name,
                Email = donor1.Email,
                Phone = donor1.Phone,
               

            };
            return getDonorDto;
        }

        public async Task<bool> DeleteDonorAsync(int id)
        {
            Donor donor = await _repository.GetByIdDonorAsync(id);
            if (donor == null )
                return false;
            for (int i = 0; i < donor.Gifts.Count(); i++)
            {
                await _giftservice.DeleteGiftAsync(donor.Gifts[i].Id);
            }

            if(donor.Gifts.Count() >0)
                return false;
            await _repository.DeleteDonorAsync(donor);
            return true;
        }

      

        public async Task<GetByIdDonorDto> UpdateDonorAsync(UpdateDonorDto updateDonorDto)
        {
            Donor donor = await _repository.GetByIdDonorAsync(updateDonorDto.Id);

            if (donor == null)
                throw new AggregateException("donor not found");
            donor.Name = updateDonorDto.Name;
            Donor donor1 = await _repository.UpdateDonorAsync(donor);

        return await GetByIdDonorDtoAsync(donor1.Id);
        }
    }
}
