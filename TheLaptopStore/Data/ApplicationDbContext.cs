using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TheLaptopStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}