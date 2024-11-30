
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UdemyCourseApi.Data;
using UdemyCourseApi.Mappings;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<NZWalksDBCOntext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));
            builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
            builder.Services.AddScoped<IWalkerRepository, SqlWalkRepository>();
            builder.Services.AddAutoMapper(typeof(AutomapperClass));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
