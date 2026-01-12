using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChineseSale.Dto
{
    public class GetDonorDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
      
    }
   public class GetByIdDonorDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
   
        public List<GetGiftDto> Gifts { get; set; } 
    }
    public class CreateDonorDto
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class UpdateDonorDto
    {
        [Required]
        public int Id { get; set; }
      
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
  
    }
