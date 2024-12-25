namespace UdemyCourseApi.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define GUIDs for roles
            var adminRoleId = "a7d1b5a1-e249-4f88-830d-b08b8e13b0b9"; // GUID for Admin role
            var vendorRoleId = "b0c7ccad-87c2-4874-8e3b-e7e2a9234056"; // GUID for Vendor role
            var readerRoleId = "e1d43a91-2c43-4e0b-8430-1b8f3e378401"; // GUID for Reader role
            var writerRoleId = "5ac1caae-d8f1-4196-975e-6fa5d25b92a7"; // GUID for Writer role

            // Define roles
            var roles = new List<IdentityRole>
            {
                new()
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
              new()
                {
                    Id = vendorRoleId,
                    ConcurrencyStamp = vendorRoleId,
                    Name = "Vendor",
                    NormalizedName = "VENDOR".ToUpper()
                },
              new()
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER".ToUpper()
                },
               new()
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER".ToUpper()
                }
            };

            // Seed roles into the database
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
