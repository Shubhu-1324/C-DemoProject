using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Data
{
    public class ProductHandlerDb :DbContext
    {
        public ProductHandlerDb(DbContextOptions<ProductHandlerDb> dbContextOptions): base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }


        public DbSet<ProductSize>ProductSizes { get; set; } 

        public DbSet<ProductImages> ProductImages { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartHandler>CartHandlers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(p => p.Sizes)
            .WithMany()
            .UsingEntity(j => j.ToTable("ProductProductSizes"));

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

            modelBuilder.Entity<ProductSize>().HasData(
                    new ProductSize
                    {
                        Id = Guid.Parse("91766ec7-1efc-44ff-bd36-bffa18e5ef20"),
                        Size = "Small"
                    },
                    new ProductSize
                    {
                        Id = Guid.Parse("acf1dc39-dc67-4b6d-bdd6-25dd9fcd90d6"),
                        Size = "Medium"
                    },
                    new ProductSize
                    {
                        Id = Guid.Parse("c001358d-d66e-4563-8f48-1d8bda05e17c"),
                        Size = "Large"
                    },
                    new ProductSize
                    {
                        Id = Guid.Parse("926f53fe-2591-4872-be84-047c0f6a8d2b"),
                        Size = "X-Large"
                    }
                ); ;


        }


    }
}
