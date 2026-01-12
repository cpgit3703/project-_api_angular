using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{
    public class GetPackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
   
        public int Price { get; set; }

        [Required]
        public int CountCard { get; set; }
    }
    public class CreatePackageDto
    {
    
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CountCard { get; set; }

    }
    public class UpdatePackageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public int Price { get; set; }
        [Required]
        public int CountCard { get; set; }

    }
}
