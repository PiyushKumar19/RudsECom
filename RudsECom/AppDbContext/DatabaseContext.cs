using Microsoft.EntityFrameworkCore;
using RudsECom.Models;

namespace RudsECom.AppDbContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}
