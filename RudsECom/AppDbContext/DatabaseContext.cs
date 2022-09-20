using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RudsECom.Models;

namespace RudsECom.AppDbContext
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<ProductGallery> ProductGallery { get; set; }
    }
}
