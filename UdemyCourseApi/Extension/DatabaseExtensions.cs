using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UdemyCourseApi.Data;

namespace UdemyCourseApi.Extension
{
    public static class DatabaseExtensions
    {
        public static void AddCustomDatabaseContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Add the first DbContext
            services.AddDbContext<NZWalksDBCOntext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NZWalksConnectionString")));

            // Add the second DbContext
            services.AddDbContext<NzWalksAuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NZWalksAuthConnectionString")));

            services.AddDbContext<ProductHandlerDb>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EcartService"))
            );
        }
    }
}
