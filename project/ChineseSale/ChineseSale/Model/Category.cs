using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Model
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public List<Gift> Gifts { get; set; }=new List<Gift>();
    }
}
