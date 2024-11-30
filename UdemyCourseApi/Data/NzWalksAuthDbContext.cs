namespace UdemyCourseApi.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class NzWalksAuthDbContext : IdentityDbContext
    {
        public NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define GUIDs for roles
            var readerRoleId = "6b378f33-1900-41c7-a721-ca76ec87e58d";
            var writerRoleId = "3d2177ea-369a-4379-bb3e-d53c6d73f2a7";

            // Define roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER".ToUpper()
                }
            };

            // Seed roles into the database
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
