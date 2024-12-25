using UdemyCourseApi.Repositories;
using UdemyCourseApi.Service;

namespace UdemyCourseApi.Extension
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RepositoryCollection(this IServiceCollection services)
        {

            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IImageProcessingService, ImageProcessing>();
           // services.AddMemoryCache();


            return services;
        }
    }
}
