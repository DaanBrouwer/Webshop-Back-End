using Microsoft.EntityFrameworkCore;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
