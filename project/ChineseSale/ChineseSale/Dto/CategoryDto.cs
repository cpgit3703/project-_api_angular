

using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{

    public class CreateCategoryDto
    {

        [Required]
        public string Name { get; set; }

    }   
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class GetCategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
      
    }
    public class GetCategoryByIdDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<GetGiftDto> Gifts { get; set; }
    }
}
