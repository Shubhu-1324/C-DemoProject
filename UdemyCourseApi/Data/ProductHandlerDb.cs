using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Data
{
    public class ProductHandlerDb(DbContextOptions<ProductHandlerDb> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Product> Products { get; set; }


        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }   

        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }


        public DbSet<CartHandler> CartHandlers { get; set; }



       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSubcategory>()
           .HasKey(ps => new {
               ps.ProductId,
               ps.SubcategoryId
           });

            modelBuilder.Entity<SubCategory>()
                    .HasOne(sc => sc.Category)  // A SubCategory has one Category (Parent)
                    .WithMany(c => c.SubCategories)  // A Category has many SubCategories
                    .HasForeignKey(sc => sc.CategoryId)  // Foreign key in SubCategory pointing to Category
                    .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps=>ps.Product)
                .WithMany(p=>p.ProductSubcategories)
                .HasForeignKey(ps => ps.ProductId)  // The foreign key in ProductSubcategory that links to Product
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSubcategory>()
            .HasOne(ps => ps.SubCategory)  // A ProductSubcategory has one Subcategory
            .WithMany(s => s.ProductSubcategories)  // A Subcategory has many ProductSubcategories
            .HasForeignKey(ps => ps.SubcategoryId)  // The foreign key in ProductSubcategory that links to Subcategory
            .OnDelete(DeleteBehavior.Cascade);  // C


            modelBuilder.Entity<Product>()
            .HasMany(p => p.Sizes)
            .WithMany()
            .UsingEntity(j => j.ToTable("ProductProductSizes"));
          

            modelBuilder.Entity<ProductImages>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Images)
               .HasForeignKey(i => i.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
           .WithMany(c => c.Products)
           .HasForeignKey(p => p.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);



           

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
