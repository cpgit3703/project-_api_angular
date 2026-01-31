using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{
    public class GetBasketDto
{
        public int Id { get; set; }
        
        public int UserId { get; set; }
      
        public double Sum { get; set; }
    }

    public class GetByUserBasketDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<GetGiftDto> Gifts { get; set; }

        public List<GetPackageDto> Packages { get; set; }
        public double Sum { get; set; }
    }
    public class CreateBasketDto
    {
        [Required]
      public int UserId { get; set; }
    }
    public class AddGiftsToBasketDto
    {
        public int BasketId { get; set; }
        public int GiftsId { get; set; }


    }
    public class DeleteGiftsFromBasketDto
    {
        public int BasketId { get; set; }
        public int GiftsId { get; set; }


    }


    public class AddPackagesToBasketDto
    {
        public int BasketId { get; set; }
        public int PackageId { get; set; }

    }
    public class DeletePackagesFromBasketDto
    {
        public int BasketId { get; set; }
        public int PackageId { get; set; }

    }
}
