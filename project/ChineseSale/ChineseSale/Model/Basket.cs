 namespace ChineseSale.Model
{
    public class Basket
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; }

        public  List<int> GiftsId { get; set;}= new List<int>();

        public List<int> PackageId { get; set; } = new List<int>();

        public double Sum { get; set; } = 0;

    }
}
