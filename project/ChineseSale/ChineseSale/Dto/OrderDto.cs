using ChineseSale.Model;
using System.ComponentModel.DataAnnotations;

namespace ChineseSale.Dto
{
    public class GetOrderDto
    {
        public int Id { get; set; }
      
        public int UserId { get; set; }
       
        public double Sum { get; set; }
        public DateTime OrdeData { get; set; }
    }
    public class GetOrderByIdDto
    {
        [Required]
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public List<GetGiftDto> GiftsId { get; set; }= new List<GetGiftDto>();
        public List<GetPackageDto> PackageId { get; set; } = new List<GetPackageDto>();
        public double Sum { get; set; }
        public DateTime OrdeData { get; set; }
    }
    public class CreateOrderDto
    {
        [Required]
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public List<int> GiftsId { get; set; }= new List<int>();

        public List<int> PackageId { get; set; } = new List<int>();
        public double Sum { get; set; }
        public DateTime OrdeData { get; set; }
    }
    


}
