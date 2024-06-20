using Microsoft.EntityFrameworkCore;
using OnlineFoodService_WebApi.Model;
using OnlineFoodService_WebApi.ViewModel;

namespace OnlineFoodService_WebApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public DbSet<Cart> Cart { get; set; }

        ////View Model
        public DbSet<RestaurantWiseMenu> RestaurantMenuItem { get; set; }
        public DbSet<OrderReceipt> OrderReceipt { get; set; }
    }
}
