using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{
    public class GetGiftDto
    {
        public int Id { get; set; }
        public GetDonorDto Donor { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    

        public GetCategoryDto Category { get; set; }
        public int SumCustomers { get; set; } = 0;
        public string Image { get; set; }
       
    }

    public class CreateGiftDto
    {
        public int Id { get; set; }
        [Required]
        public int DonorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
     
        [Required]
        public int CategoryId { get; set; }
        public string Image { get; set; }

      
    }
    public class UpdateGiftDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DonorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
       
        [Required]
        public int CategoryId { get; set; }
        public string Image { get; set; }

    }

}
