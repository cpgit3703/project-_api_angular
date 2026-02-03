using ChineseSale.Dto;
using ChineseSale.Model;
using ChineseSale.Repositories;

namespace ChineseSale.Services
{
    public class PackegeService : IPackegeService
    {
        private readonly IPackegeReposetory _repository;
        public PackegeService(IPackegeReposetory repository)
        {

            _repository = repository;
        }

        public async Task<IEnumerable<GetPackageDto>> GetAllPackageAsync()
        {

            IEnumerable<Package> packages = await _repository.GetAllPackageAsync();
            List<GetPackageDto> getPackageDtos = new List<GetPackageDto>();

            foreach (var package in packages)
            {
                GetPackageDto getPackageDto = new GetPackageDto()
                {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    Price = package.Price,
                    CountCard = package.CountCard,
                    Image = package.Image


                };

                getPackageDtos.Add(getPackageDto);
            }

            return getPackageDtos;
        }
        public async Task<GetPackageDto?> GetByIdPackageAsync(int Id)
        {
            Package package = await _repository.GetByIdPackageAsync(Id);
            if (package == null)
                throw new AggregateException("package not found");
      
            GetPackageDto getPackageDto = new GetPackageDto()
            {
                
                Id = package.Id,
                Name = package.Name,
                Description = package.Description,
                Price = package.Price,
                CountCard = package.CountCard,
                Image = package.Image


            };
            return getPackageDto;
        }
        public async Task<GetPackageDto> CreatePackageAsync(CreatePackageDto PackageDto)
        {
            if(PackageDto.Price<0)
                throw new AggregateException("Price must be non-negative");

            Package package = new Package()
            {
               
                Name = PackageDto.Name,
                Description = PackageDto.Description,
                Price = PackageDto.Price,
                CountCard = PackageDto.CountCard,
                Image = PackageDto.Image


            };
            
            await _repository.CreatePackageAsync(package);
            Package package1 = await _repository.GetByIdPackageAsync(package.Id);
            GetPackageDto getPackageDto = new GetPackageDto()
            {
               
                Id = package1.Id,
                Name = package1.Name,
                Description = package1.Description,
                Price = package1.Price,
                CountCard = package1.CountCard,
                Image = package1.Image
                
            };
            return getPackageDto;

        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            Package package = await _repository.GetByIdPackageAsync(id);
            if (package == null )
                return false;
            await _repository.DeletePackageAsync(package);
             return true;
        }
        public async Task<GetPackageDto> UpdatePackageAsync(UpdatePackageDto packageDto)
        {
         
            Package package = await _repository.GetByIdPackageAsync(packageDto.Id);
            
            if (package == null)
                throw new AggregateException("package not found");
             if(packageDto.Price<0)
                throw new AggregateException("Price must be non-negative");
       
            package.Name = packageDto.Name;
            package.Description = packageDto.Description;
            package.Price = packageDto.Price;
            package.CountCard=packageDto.CountCard;
            package.Image = packageDto.Image;
    

            
            Package updatedPackage = await _repository.UpdatePackageAsync(package);

           
            return await GetByIdPackageAsync(updatedPackage.Id);
        }

    }
}

