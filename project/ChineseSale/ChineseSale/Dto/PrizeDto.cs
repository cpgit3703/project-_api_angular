using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{
    public class GetPrizeDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int GiftId { get; set; }
        
    }
    public class CreatePrizeDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GiftId { get; set; }
    }
}
