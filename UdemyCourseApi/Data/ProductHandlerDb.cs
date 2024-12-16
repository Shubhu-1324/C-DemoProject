using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Data
{
    public class ProductHandlerDb :DbContext
    {
        public ProductHandlerDb(DbContextOptions<ProductHandlerDb> dbContextOptions): base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }


        public DbSet<ProductImages> ProductImages { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartHandler>CartHandlers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductImages>()
                .HasOne(i=>i.Product)
                .WithMany(p=>p.Images)
               .HasForeignKey(i => i.ProductId);


            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Men",
                    ParentCategoryId = null
                },
                 new Category
                 {
                     Id = Guid.NewGuid(),
                     Name = "Women",
                     ParentCategoryId = null
                 },
                  new Category
                  {
                      Id = Guid.NewGuid(),
                      Name = "Child",
                      ParentCategoryId = null
                  }
                );
        }


    }
}
