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
        public int GiftstId { get; set; }
      
    }
    public class DeleteGiftsFromBasketDto
    {
        public int BasketId { get; set; }
        public int GiftstId { get; set; }

    }
}
