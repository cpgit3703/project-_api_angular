using ChineseSale.Data;
using Microsoft.EntityFrameworkCore;

namespace ChineseSale.Data
{
    public class ChineseSaleContextFactory
    {
        //private const string ConnectionString = "Server=DESKTOP-P3U8QIP;Database=ChineseSale_329213227;Integrated Security=True;\r\n Security=True;\r\n Security=SSPI;" +
        //    "Persist Security Info=False;TrustServerCertificate=true";
        private const string ConnectionString = "Server=CYPY;Database=ChineseSale_329213227;Trusted_Connection=True;TrustServerCertificate=True;"
;

        public static ChineseSaleDbContext CreateContext()
        {
            var optionsBuilder=new DbContextOptionsBuilder<ChineseSaleDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ChineseSaleDbContext(optionsBuilder.Options);
        }
    }
}
