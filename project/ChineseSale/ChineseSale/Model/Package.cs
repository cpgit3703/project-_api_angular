using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Model
{
    public class Package
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
      
        public int Price { get; set;}
        [Required]
        public int CountCard { get; set; } = 0;

    }
}
