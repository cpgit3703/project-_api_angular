using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChineseSale.Model
{
    public class Donor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public List<Gift> Gifts { get; set; }= new List<Gift>();
    }
}
