using UdemyCourseApi.Mappings;

namespace UdemyCourseApi.Extension
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AutomapperCollection(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(AutomapperClass));
            return services;
        }
    }
}
