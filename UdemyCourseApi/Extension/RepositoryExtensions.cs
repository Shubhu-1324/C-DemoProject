using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Extension
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RepositoryCollection(this IServiceCollection services)
        {

            services.AddScoped<IRegionRepository, SqlRegionRepository>();
            services.AddScoped<IWalkerRepository, SqlWalkRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }
    }
}
