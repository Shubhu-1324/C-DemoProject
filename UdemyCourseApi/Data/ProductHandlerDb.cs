using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Data
{
    public class ProductHandlerDb :DbContext
    {
        public ProductHandlerDb(DbContextOptions<ProductHandlerDb> dbContextOptions): base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); 
        }


    }
}
