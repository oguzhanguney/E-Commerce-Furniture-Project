using Furniture.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Furniture.DataLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4M0OQRD\SQLEXPRESS;Database=FurnitureDb;User Id=pixxaer;Password=453885;Encrypt=false;TrustServerCertificate=true;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-BAPR309;Database=FurnitureDb;TrustServerCertificate=true;Trusted_Connection=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
    }
}
