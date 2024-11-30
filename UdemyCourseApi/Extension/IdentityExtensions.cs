using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using UdemyCourseApi.Data;

namespace UdemyCourseApi.Extension
{
    public static class IdentityExtensions
    {
        public static IServiceCollection IdentityCollection(this IServiceCollection services)
        {
            services.AddIdentityCore<IdentityUser>()
                     .AddRoles<IdentityRole>()
                     .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NzWalks")
                     .AddEntityFrameworkStores<NzWalksAuthDbContext>()
                     .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase=false;

            });
            return services;
        }
    }
}
