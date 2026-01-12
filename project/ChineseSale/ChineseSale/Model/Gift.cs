using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChineseSale.Model
{
    
    public class Gift
    {

        public int Id { get; set; }
        public int DonorId { get; set; }
        [Required]
 
        public Donor Donor { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        [Required]
        public int PriceCard { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int SumCustomers { get; set; } = 0;

        public string Image { get; set; }

    }

}
