using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;
using System.Collections.Generic;

namespace ChineseSale.Services
{
    public class CategoryService : ICategoryServices
    {

        private readonly ICategoryReposetory _repository;
        public CategoryService(ICategoryReposetory repository)
        {

            _repository = repository;
        }
        public async Task<GetCategoryDto> CreateCategoryAsync(CreateCategoryDto CategoryDto)
        {
            Category category = new Category()
            {
                Name = CategoryDto.Name
            };
            await _repository.CreateCategoryAsync(category);
            Category category1 =await _repository.GetByIdCategoryAsync(category.Id);
            GetCategoryDto getCategoryDto = new GetCategoryDto()
            {
                Id = category1.Id,
                Name = category1.Name
            };
            return getCategoryDto;

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            Category category = await _repository.GetByIdCategoryAsync(id);
            if (category == null || category.Gifts.Count()>0)
                        return false;
            await _repository.DeleteCategoryAsync(category);
     return true;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllCategoryAsync()
        {

            IEnumerable<Category> categories = await _repository.GetAllCategoryAsync();
            List<GetCategoryDto> giftdtos = new List<GetCategoryDto>();

            foreach (var category in categories)
            {
                GetCategoryDto getCategoryDto = new GetCategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                giftdtos.Add(getCategoryDto);
            }

            return giftdtos;
        }

        public async Task<GetCategoryByIdDto?> GetByIdCategoryAsync(int Id)
        {
            Category category = await _repository.GetByIdCategoryAsync(Id);
            if (category == null)
                throw new AggregateException("category not found");   
          List < GetGiftDto > giftdtos = new List<GetGiftDto>();
            foreach (var gift in category.Gifts)
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
            GetCategoryByIdDto getCategoryByIdDto = new GetCategoryByIdDto()
            {
                Id = category.Id,
                Name = category.Name,
                Gifts= giftdtos
                  };
            return getCategoryByIdDto;
        }

        public async Task<GetCategoryByIdDto> UpdateCategoryAsync(UpdateCategoryDto CategoryDto)
        {
            Category category = await _repository.GetByIdCategoryAsync(CategoryDto.Id);

            if (category == null)
                throw new AggregateException("category not found");
            category.Name = CategoryDto.Name;
            Category category1 = await _repository.UpdateCategoryAsync(category);

            return await GetByIdCategoryAsync(category1.Id);
        }
    }
}
