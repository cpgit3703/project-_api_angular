
using ChineseSale.Model;
using Microsoft.EntityFrameworkCore;


namespace ChineseSale.Data
{
    public class ChineseSaleDbContext : DbContext
    {
        public ChineseSaleDbContext(DbContextOptions<ChineseSaleDbContext> options) : base(options) { }

        public DbSet<Basket> Baskets => Set<Basket>();

        public DbSet<Prize> Prizes => Set<Prize>();

        public DbSet<Gift> Gifts => Set<Gift>();

        public DbSet<User> Users => Set<User>();

        public DbSet<Donor> Donors => Set<Donor>();

        public DbSet<Category> Categorys => Set<Category>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<Package> Packages => Set<Package>();

      //  public ChineseSaleDbContext(DbContextOptions<ChineseSaleDbContext> options)
      //: base(options)
      //  {
      //  }

      //  protected override void OnModelCreating(ModelBuilder modelBuilder)
      //  {
      //      base.OnModelCreating(modelBuilder);
      //      // Email ייחודי לתורם
      //      modelBuilder.Entity<User>()
      //          .HasIndex(d => d.Email)
      //          .IsUnique();


        }
    }