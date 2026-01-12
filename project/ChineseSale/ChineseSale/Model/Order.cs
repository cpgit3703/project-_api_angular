using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Model
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<int> GiftsId { get; set; } = new List<int>();
        public double Sum { get; set; }
        public DateTime OrdeData { get; set; }
    }
}
